using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VRP.Core.Enums;
using VRP.Core.Extensions;
using VRP.DAL.Core;
using VRP.Dtos;
using VRP.Dtos.Core;
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

            base.CreateBulk(items.ToList());

            return GetListNoTracking(x => x.DataSetId == dataSetId, orderBys: CreateOrderBys(new OrderByDescending<DataSetItem, long>(x => x.Id)), take: 100);
        }

        public SearchResult<DataSetItemModel> Search(DataSetItemSearchModel model) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            return new SearchResult<DataSetItemModel> {
                Total = Count(SearchPredicate(model)),
                Items = GetListNoTracking(
                    SearchPredicate(model),
                    orderBys: string.Equals(model.Direction, "asc", StringComparison.InvariantCultureIgnoreCase) ? AscendingOrderBys(model.Sort) : DescendingOrderBys(model.Sort),
                    skip: model.Skip,
                    take: model.Limit)
            };
        }

        #endregion

        private static Expression<Func<DataSetItem, bool>> SearchPredicate(DataSetItemSearchModel model) {
            Expression<Func<DataSetItem, bool>> predicate = a => true;

            if (model == null) {
                return predicate;
            }

            predicate = predicate.And(x => x.DataSetId == model.DataSetId && x.DataSetType == model.DataSetType);

            if (!string.IsNullOrEmpty(model.Query)) {
                predicate = predicate.And(x =>
                    x.District.Contains(model.Query) ||
                    x.ProductType.Contains(model.Query));
            }

            return predicate;
        }

        private List<IOrderBy<DataSetItem>> DescendingOrderBys(string field) {
            if (string.Equals(field, "InsertDate", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderByDescending<DataSetItem, DateTime>(x => x.InsertDate));
            }

            return CreateOrderBys(new OrderByDescending<DataSetItem, long>(x => x.Id));
        }

        private List<IOrderBy<DataSetItem>> AscendingOrderBys(string field) {
            if (string.Equals(field, "InsertDate", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderBy<DataSetItem, DateTime>(x => x.InsertDate));
            }

            return CreateOrderBys(new OrderBy<DataSetItem, long>(x => x.Id));
        }
    }
}
