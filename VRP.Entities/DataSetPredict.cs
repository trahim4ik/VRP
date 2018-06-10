using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class DataSetPredict : IId<long>, IEntity {
        public long Id { get; set; }
        public double Target { get; set; }
        public double Predict { get; set; }
        public long DataSetId { get; set; }
        public DataSet DataSet { get; set; }
    }
}
