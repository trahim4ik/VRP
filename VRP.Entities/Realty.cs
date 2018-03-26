using System;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class Realty : IId<long>, IEntity, IExpirable {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ZipCode { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
