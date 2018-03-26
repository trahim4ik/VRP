using System;
using System.Collections.Generic;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class DataSet : IId<long>, IEntity, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<DataSetItem> DataSetItems { get; set; }
    }
}
