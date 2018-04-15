using System.Collections.Generic;
using VRP.Dtos;

namespace VRP.Services.Interfaces {
    public interface IDataSetParser {
        IEnumerable<DataSetItemModel> Parse(string file);
    }
}
