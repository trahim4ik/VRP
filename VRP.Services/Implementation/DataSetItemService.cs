using System;
using System.Collections.Generic;
using System.Linq;
using VRP.Core.Enums;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetItemService : BaseService<DataSetItem, DataSetItemModel>, IDataSetItemService {

        #region Constructor

        public DataSetItemService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        #endregion


        #region Implementation IDataSetItemService

        #endregion

        public IEnumerable<DataSetItemModel> Create(IEnumerable<DataSetItemModel> items, long dataSetId, DataSetType type = DataSetType.Train) {
            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }

            if (dataSetId == 0) {
                throw new ArgumentException(nameof(dataSetId));
            }

            items = items.Select(x => {
                x.DataSetId = dataSetId;
                x.DataSetType = type;
                return x;
            });

            return base.Create(items.ToList());
        }
    }
}
