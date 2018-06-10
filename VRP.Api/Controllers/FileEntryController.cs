using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VRP.Core.Options;
using VRP.DAL.Core;
using VRP.Entities;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class FileEntryController : BaseController {

        #region Variables

        private readonly IFileEntryService _fileEntryService;
        private readonly IOptions<FileSystemOptions> _fileSystemOptions;

        #endregion

        #region Constructor

        public FileEntryController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _fileEntryService = ServiceProvider.GetRequiredService<IFileEntryService>();
            _fileSystemOptions = ServiceProvider.GetRequiredService<IOptions<FileSystemOptions>>();
        }

        #endregion

        #region API

        [HttpGet("{id}")]
        public async Task<IActionResult> Download(long id) {
            var filename = _fileEntryService.GetSingleNoTracking(x => x.Id == id, select: x => x.Name);

            if (filename == null) {
                return Content("filename not present");
            }

            var path = Path.Combine(_fileSystemOptions.Value.Content, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open)) {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path) {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes() {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".eg",  "text/plain"}
            };
        }

        #endregion

    }
}
