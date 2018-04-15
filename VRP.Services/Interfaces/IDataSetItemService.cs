using System.Collections.Generic;
using VRP.Core.Enums;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;

namespace VRP.Services.Interfaces {
    public interface IDataSetItemService : IBaseService<DataSetItem, DataSetItemModel> {
        IEnumerable<DataSetItemModel> Create(IEnumerable<DataSetItemModel> items, long dataSetId, DataSetType type = DataSetType.Train);
    }
}
