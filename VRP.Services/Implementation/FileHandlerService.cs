using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VRP.Core.Options;
using VRP.Dtos;
using VRP.Services.Extensions;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class FileHandlerService : IFileHandlerService {

        #region Variables

        private readonly IFileEntryService _fileEntryService;
        private readonly FileSystemOptions _fileSystemOptions;

        #endregion

        #region Constructor

        public FileHandlerService(IServiceProvider serviceProvider, IOptions<FileSystemOptions> options) {
            _fileEntryService = serviceProvider.GetRequiredService<IFileEntryService>();
            _fileSystemOptions = options.Value ?? throw new InvalidDataException("Invalid file system  options provided.");
        }

        #endregion

        #region Implementation IFileHandlerService

        public async Task<FileEntryModel> Upload(IFormFile file) {
            if (Directory.Exists(_fileSystemOptions.Content)) {
                Directory.CreateDirectory(_fileSystemOptions.Content);
            }

            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var extension = Path.GetExtension(fileName);

            var fileEntry = new FileEntryModel {
                ContentType = file.ContentType,
                FileName = file.FileName,
                Name = $"{Guid.NewGuid().ToString()}{extension}",
                Extension = extension,
                Length = file.Length
            };

            var fullPath = Path.Combine(_fileSystemOptions.Content, fileEntry.Name);

            await file.SaveAsAsync(fullPath);

            return _fileEntryService.Create(fileEntry);
        }

        #endregion


    }
}
