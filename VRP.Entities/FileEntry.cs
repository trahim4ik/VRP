using System;
using System.Collections.Generic;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class FileEntry : IId<long>, IEntity, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public ICollection<DataSetFileEntry> DataSetFileEntries { get; set; }
    }
}
