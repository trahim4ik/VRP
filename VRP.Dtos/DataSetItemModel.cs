using System;
using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class DataSetItemModel : IId<long>, IDto, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long DataSetId { get; set; }
    }
}
