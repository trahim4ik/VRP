using Encog.Neural.Networks;

namespace VRP.NeuronNetwork.Models {
    public class TrainResultModel {
        public BasicNetwork Network { get; set; }
        public double Error { get; set; }
    }
}
