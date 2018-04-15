using VRP.Core.Enums;
using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class DataSetFileEntryModel : IDto {
        public long FileEntryId { get; set; }
        public FileEntryModel FileEntry { get; set; }
        public long DataSetId { get; set; }
        public DataSetModel DataSet { get; set; }
        public DataSetType DataSetType { get; set; }
    }
}
