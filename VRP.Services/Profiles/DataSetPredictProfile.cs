using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class DataSetPredictProfile : Profile {
        public DataSetPredictProfile() {
            CreateMap<DataSetPredict, DataSetPredictModel>();
            CreateMap<DataSetPredictModel, DataSetPredict>();
        }
    }
}
