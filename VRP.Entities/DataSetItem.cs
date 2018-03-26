using System;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class DataSetItem : IId<long>, IEntity, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long DataSetId { get; set; }
        public DataSet DataSet { get; set; }
    }
}
