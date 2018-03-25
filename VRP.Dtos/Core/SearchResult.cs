using System.Collections.Generic;
using VRP.Core.Interfaces;

namespace VRP.Dtos.Core {
    public class SearchResult<T> where T : IDto {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
