using VRP.Core.Enums;
using VRP.Dtos.Core;

namespace VRP.Dtos {
    public class DataSetItemSearchModel : SearchModel {
        public DataSetType DataSetType { get; set; }
        public long DataSetId { get; set; }
    }
}
