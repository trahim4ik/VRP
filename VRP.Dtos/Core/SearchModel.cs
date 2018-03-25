namespace VRP.Dtos.Core {
    public class SearchModel {
        public string Query { get; set; }
        public string Sort { get; set; }
        public string Direction { get; set; }
        public int Limit { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
    }
}
