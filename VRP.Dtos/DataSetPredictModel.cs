using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class DataSetPredictModel : IId<long>, IDto {
        public long Id { get; set; }
        public double Target { get; set; }
        public double Predict { get; set; }
        public long DataSetId { get; set; }
    }
}
