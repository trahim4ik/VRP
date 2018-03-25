using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class UserService : BaseService<User, UserModel>, IUserService {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
