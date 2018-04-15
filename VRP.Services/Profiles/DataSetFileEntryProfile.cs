using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetFileEntryProfile : Profile {
        public DataSetFileEntryProfile() {
            CreateMap<DataSetFileEntry, DataSetFileEntryModel>();
            CreateMap<DataSetFileEntryModel, DataSetFileEntry>();
        }
    }
}
