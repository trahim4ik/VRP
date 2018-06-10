using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetPredictService : BaseService<DataSetPredict, DataSetPredictModel>, IDataSetPredictService {
        public DataSetPredictService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
