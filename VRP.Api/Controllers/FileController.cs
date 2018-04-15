using System;
using Microsoft.AspNetCore.Mvc;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class FileController : BaseController {

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

    }
}
