using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using VRP.Api.Core;
using VRP.Entities;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class FileController : BaseController {

        private static readonly FormOptions DefaultFormOptions = new FormOptions();

        public FileController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files) {
            var size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files) {
                if (formFile.Length <= 0) continue;
                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    await formFile.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }

        [HttpPost]
        [Route("Upload")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload() {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType)) {
                return BadRequest($"Expected a multipart request, but got {Request.ContentType}");
            }

            // Used to accumulate all the form url encoded key value pairs in the 
            // request.
            var formAccumulator = new KeyValueAccumulator();
            string targetFilePath = null;

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                DefaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();
            while (section != null) {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader) {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition)) {
                        targetFilePath = Path.GetTempFileName();
                        using (var targetStream = System.IO.File.Create(targetFilePath)) {
                            await section.Body.CopyToAsync(targetStream);

                            //_logger.LogInformation($"Copied the uploaded file '{targetFilePath}'");
                        }
                    } else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition)) {
                        // Content-Disposition: form-data; name="key"
                        //
                        // value

                        // Do not limit the key name length here because the 
                        // multipart headers length limit is already in effect.
                        var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name).Value;
                        var encoding = GetEncoding(section);
                        using (var streamReader = new StreamReader(
                            section.Body,
                            encoding,
                            detectEncodingFromByteOrderMarks: true,
                            bufferSize: 1024,
                            leaveOpen: true)) {
                            // The value length limit is enforced by MultipartBodyLengthLimit
                            var value = await streamReader.ReadToEndAsync();
                            if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase)) {
                                value = String.Empty;
                            }
                            formAccumulator.Append(key, value);

                            if (formAccumulator.ValueCount > DefaultFormOptions.ValueCountLimit) {
                                throw new InvalidDataException($"Form key count limit {DefaultFormOptions.ValueCountLimit} exceeded.");
                            }
                        }
                    }
                }

                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            // Bind form data to a model
            var user = new User();
            var formValueProvider = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);

            var bindingSuccessful = await TryUpdateModelAsync(user, prefix: "",
                valueProvider: formValueProvider);
            if (!bindingSuccessful) {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }
            }

            return Json(targetFilePath);
        }

        private static Encoding GetEncoding(MultipartSection section) {
            var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out var mediaType);
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding)) {
                return Encoding.UTF8;
            }
            return mediaType.Encoding;
        }

    }
}
