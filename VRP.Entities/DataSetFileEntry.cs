using VRP.Core.Enums;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class DataSetFileEntry : IEntity {
        public long FileEntryId { get; set; }
        public FileEntry FileEntry { get; set; }
        public long DataSetId { get; set; }
        public DataSet DataSet { get; set; }
        public DataSetType DataSetType { get; set; }
    }
}
