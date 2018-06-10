using System;
using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class DataSetNetworkModel : IId<long>, IDto {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long DataSetId { get; set; }
        public long FileEntryId { get; set; }
        public double Error { get; set; }
        public FileEntryModel FileEntry { get; set; }
    }
}
