using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class FileEntryService : BaseService<FileEntry, FileEntryModel>, IFileEntryService {
        public FileEntryService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
