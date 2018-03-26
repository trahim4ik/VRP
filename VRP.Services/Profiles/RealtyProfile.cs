using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class RealtyProfile : Profile {
        public RealtyProfile() {
            CreateMap<Realty, RealtyModel>();
            CreateMap<RealtyModel, Realty>();
        }
    }
}
