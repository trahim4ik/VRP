using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using VRP.Core.Extensions;
using VRP.DAL.Core;
using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetService : BaseService<DataSet, DataSetModel>, IDataSetService {

        #region Variables

        private readonly IBaseService<DataSetFileEntry, DataSetFileEntryModel> _dataSetFileEntryService;

        #endregion

        #region Constructor

        public DataSetService(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetFileEntryService = ServiceProvider.GetRequiredService<IBaseService<DataSetFileEntry, DataSetFileEntryModel>>();
        }

        #endregion

        #region Implementation IDataSetService

        public override DataSetModel Update(DataSetModel model) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            var dataSetFilesIds = model.FileEntries.Where(x => x.Id != 0).Select(x => x.Id);

            _dataSetFileEntryService.Delete(x => x.DataSetId == model.Id && !dataSetFilesIds.Contains(x.FileEntryId));
            var filesToCreate = model.FileEntries.Where(x => x.Id == 0)
                .Select(x => new DataSetFileEntryModel { DataSetId = model.Id, FileEntry = x })
                .ToList();

            _dataSetFileEntryService.Create(filesToCreate);

            return base.Update(model);
        }

        public SearchResult<DataSetModel> Search(SearchModel model) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            return new SearchResult<DataSetModel> {
                Total = Count(SearchPredicate(model)),
                Items = GetListNoTracking(
                    SearchPredicate(model),
                    orderBys: string.Equals(model.Direction, "asc", StringComparison.InvariantCultureIgnoreCase) ? AscendingOrderBys(model.Sort) : DescendingOrderBys(model.Sort),
                    skip: model.Skip,
                    take: model.Limit)
            };
        }

        private static Expression<Func<DataSet, bool>> SearchPredicate(SearchModel model) {
            Expression<Func<DataSet, bool>> predicate = a => true;

            if (model == null) {
                return predicate;
            }

            if (!string.IsNullOrEmpty(model.Query)) {
                predicate = predicate.And(x =>
                    x.Name.Contains(model.Query) ||
                    x.Description.Contains(model.Query));
            }

            return predicate;
        }

        private List<IOrderBy<DataSet>> DescendingOrderBys(string field) {
            if (string.Equals(field, "InsertDate", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderByDescending<DataSet, DateTime>(x => x.InsertDate));
            }

            if (string.Equals(field, "Name", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderByDescending<DataSet, string>(x => x.Name));
            }

            if (string.Equals(field, "Description", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderByDescending<DataSet, string>(x => x.Description));
            }

            return CreateOrderBys(new OrderByDescending<DataSet, long>(x => x.Id));
        }

        private List<IOrderBy<DataSet>> AscendingOrderBys(string field) {
            if (string.Equals(field, "InsertDate", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderBy<DataSet, DateTime>(x => x.InsertDate));
            }

            if (string.Equals(field, "Name", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderBy<DataSet, string>(x => x.Name));
            }

            if (string.Equals(field, "Description", StringComparison.InvariantCultureIgnoreCase)) {
                return CreateOrderBys(new OrderBy<DataSet, string>(x => x.Description));
            }

            return CreateOrderBys(new OrderBy<DataSet, long>(x => x.Id));
        }

        #endregion

    }
}
