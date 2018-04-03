using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using VRP.Api.Extensions;
using VRP.Dtos;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class FileController : BaseController {

        private string _folder = "c:\\VRP";

        public FileController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [Route("Download/{id}")]
        [HttpGet]
        public IActionResult Download(int id) {
            //var fileDescription = _fileRepository.GetFileDescription(id);

            //var path = _optionsApplicationConfiguration.Value.ServerUploadFolder + "\\" + fileDescription.FileName;
            //var stream = new FileStream(path, FileMode.Open);
            //return File(stream, fileDescription.ContentType);
            return Ok();
        }

        [Route("Upload")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file) {
            if (!Directory.Exists(_folder)) {
                Directory.CreateDirectory(_folder);
            }

            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
            var fullPath = Path.Combine(_folder, fileName);
            await file.SaveAsAsync(fullPath);

            return Ok(new FileEntryModel {
                ContentType = file.ContentType,
                FileName = file.FileName
            });
        }
    }
}
