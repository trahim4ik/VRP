using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class RoleProfile : Profile {
        public RoleProfile() {
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();
        }
    }
}
