﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class FileController : BaseController {
        protected FileController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [HttpPost("UploadFiles")]
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

    }
}
