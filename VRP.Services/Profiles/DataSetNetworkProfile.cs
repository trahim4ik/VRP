using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetNetworkProfile : Profile {
        public DataSetNetworkProfile() {
            CreateMap<DataSetNetwork, DataSetNetworkModel>();
            CreateMap<DataSetNetworkModel, DataSetNetwork>();
        }
    }
}
