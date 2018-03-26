using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetItemProfile : Profile {
        public DataSetItemProfile() {
            CreateMap<DataSetItem, DataSetItemModel>();
            CreateMap<DataSetItemModel, DataSetItem>();
        }
    }
}
