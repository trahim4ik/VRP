using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetItemService : BaseService<DataSetItem, DataSetItemModel>, IDataSetItemService {
        public DataSetItemService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}
