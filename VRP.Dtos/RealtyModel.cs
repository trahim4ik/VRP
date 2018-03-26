using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class RealtyModel : IDto, IId<long> {
        public long Id { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ZipCode { get; set; }
        public long UserId { get; set; }
    }
}
