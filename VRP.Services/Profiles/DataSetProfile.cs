using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetProfile : Profile {
        public DataSetProfile() {
            CreateMap<DataSet, DataSetModel>();
            CreateMap<DataSetModel, DataSet>();
        }
    }
}
