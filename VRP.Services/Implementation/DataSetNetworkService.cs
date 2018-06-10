using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetNetworkService : BaseService<DataSetNetwork, DataSetNetworkModel>, IDataSetNetworkService {
        public DataSetNetworkService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
