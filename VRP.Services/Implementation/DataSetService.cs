using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetService : BaseService<DataSet, DataSetModel>, IDataSetService {
        public DataSetService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
