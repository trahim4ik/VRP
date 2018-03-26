using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class RealtyService : BaseService<Realty, RealtyModel>, IRealtyService {
        public RealtyService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
