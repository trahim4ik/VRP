using Encog.Neural.Networks;
using System.Collections.Generic;
using System.IO;
using VRP.NeuronNetwork.Models;

namespace VRP.NeuronNetwork {
    public interface INetwork {

        #region Properties

        FileInfo BaseFile { get; set; }
        FileInfo ShuffledFile { get; set; }
        FileInfo TrainingFile { get; set; }
        FileInfo EvaluateFile { get; set; }
        FileInfo EvaluateFileOutput { get; set; }
        FileInfo NormalizedTrainingFile { get; set; }
        FileInfo NormalizedEvaluateFile { get; set; }
        FileInfo AnalystFile { get; set; }
        FileInfo TrainedNetworkFile { get; set; }
        double Error { get; set; }
        List<PredictResultModel> PredictResult { get; set; }

        #endregion

        /// <summary>
        /// Creare Elman neuron network
        /// </summary>
        /// <returns></returns>
        INetwork BuildElmanNetwork();

        /// <summary>
        /// Creare Feedforward neuron network
        /// </summary>
        /// <returns></returns>
        INetwork BuildFeedforwardNetwork();

        /// <summary>
        /// Creare Jordan neuron network
        /// </summary>
        /// <returns></returns>
        INetwork BuildJordanNetwork();

        /// <summary>
        /// Shuffle CSV Data File
        /// </summary>
        /// <returns></returns>
        INetwork Shuffle();

        /// <summary>
        /// Generate Training and Evaluation File
        /// </summary>
        /// <returns></returns>
        INetwork Segregate();

        /// <summary>
        /// Normalize Training and Evaluation Data
        /// </summary>
        /// <returns></returns>
        INetwork Normalize();

        /// <summary>
        /// Create Neural Network
        /// </summary>
        /// <returns></returns>
        INetwork CreateNetwork();

        /// <summary>
        /// Train Neural Network
        /// </summary>
        /// <returns></returns>
        INetwork TrainNetwork();

        /// <summary>
        /// Evaluate Network
        /// </summary>
        INetwork Evaluate();
    }
}