using System;
using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class FileEntryModel : IId<long>, IDto, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Length { get; set; }
    }
}
