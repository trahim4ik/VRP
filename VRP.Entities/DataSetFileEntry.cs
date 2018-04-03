namespace VRP.Entities {
    public class DataSetFileEntry {
        public long FileEntryId { get; set; }
        public FileEntry FileEntry { get; set; }
        public long DataSetId { get; set; }
        public DataSet DataSet { get; set; }
    }
}
