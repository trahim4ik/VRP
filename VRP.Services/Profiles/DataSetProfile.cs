using System.Linq;
using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetProfile : Profile {
        public DataSetProfile() {
            CreateMap<DataSet, DataSetModel>()
                .ForMember(dest => dest.FileEntries, opt => opt.MapFrom(src => src.DataSetFileEntries.Select(x => x.FileEntry)));
            CreateMap<DataSetModel, DataSet>();
        }
    }
}
