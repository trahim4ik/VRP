using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class FileEntryProfile : Profile {
        public FileEntryProfile() {
            CreateMap<FileEntry, FileEntryModel>();
            CreateMap<FileEntryModel, FileEntry>();
        }
    }
}
