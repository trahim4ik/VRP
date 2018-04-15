using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Entities;
using VRP.Services.Core;

namespace VRP.Services.Interfaces {
    public interface IDataSetService : IBaseService<DataSet, DataSetModel> {
        SearchResult<DataSetModel> Search(SearchModel model);

    }
}
