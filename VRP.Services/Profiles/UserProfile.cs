using AutoMapper;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Services.Profiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
