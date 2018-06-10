using Encog.App.Analyst;
using Encog.App.Analyst.CSV.Normalize;
using Encog.App.Analyst.CSV.Segregate;
using Encog.App.Analyst.CSV.Shuffle;
using Encog.App.Analyst.Wizard;
using Encog.Engine.Network.Activation;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.Pattern;
using Encog.Persist;
using Encog.Util.CSV;
using Encog.Util.Simple;
using System;
using System.Collections.Generic;
using System.IO;
using VRP.NeuronNetwork.Models;

namespace VRP.NeuronNetwork {
    public class Network : INetwork {

        #region Properties

        public FileInfo BaseFile { get; set; }
        public FileInfo ShuffledFile { get; set; }
        public FileInfo TrainingFile { get; set; }
        public FileInfo EvaluateFile { get; set; }
        public FileInfo EvaluateFileOutput { get; set; }
        public FileInfo NormalizedTrainingFile { get; set; }
        public FileInfo NormalizedEvaluateFile { get; set; }
        public FileInfo AnalystFile { get; set; }
        public FileInfo TrainedNetworkFile { get; set; }
        public double Error { get; set; }
        public List<PredictResultModel> PredictResult { get; set; } = new List<PredictResultModel>();

        #endregion

        #region Variables

        private static int InputCount = 63;
        private static int OutputCount = 1;
        private static int HiddenCount = 1;
        private static int MaxEpochs = 200;
        private static double Rate = 0.01;

        #endregion

        #region Implementation INetwork

        /// <see cref="INetwork.Shuffle"/>
        public INetwork Shuffle() {

            var shuffle = new ShuffleCSV();

            shuffle.Analyze(BaseFile, true, CSVFormat.English);
            shuffle.ProduceOutputHeaders = true;
            shuffle.Process(ShuffledFile);

            return this;
        }

        /// <see cref="INetwork.Segregate"/>
        public INetwork Segregate() {

            var seg = new SegregateCSV();

            seg.Targets.Add(new SegregateTargetPercent(TrainingFile, 95));
            seg.Targets.Add(new SegregateTargetPercent(EvaluateFile, 5));

            seg.ProduceOutputHeaders = true;

            seg.Analyze(BaseFile, true, CSVFormat.English);
            seg.Process();

            return this;
        }

        /// <see cref="INetwork.Normalize"/>
        public INetwork Normalize() {

            //Analyst
            var analyst = new EncogAnalyst();

            //Wizard
            var wizard = new AnalystWizard(analyst);
            wizard.Wizard(BaseFile, true, AnalystFileFormat.DecpntComma);

            // Configure normalized fields
            ConfigureNormalizedFields(analyst);

            //Norm for Trainng
            var norm = new AnalystNormalizeCSV();
            norm.Analyze(TrainingFile, true, CSVFormat.English, analyst);
            norm.ProduceOutputHeaders = true;
            norm.Normalize(NormalizedTrainingFile);

            //Norm of evaluation
            norm.Analyze(EvaluateFile, true, CSVFormat.English, analyst);
            norm.ProduceOutputHeaders = true;
            norm.Normalize(NormalizedEvaluateFile);

            //Save the analyst file
            analyst.Save(AnalystFile);

            return this;
        }

        /// <see cref="INetwork.CreateNetwork"/>
        public INetwork CreateNetwork() {
            if (TrainedNetworkFile.Exists) {
                return this;
            }

            BasicNetwork network = new BasicNetwork();

            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, InputCount));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, OutputCount));

            network.Structure.FinalizeStructure();
            network.Reset();

            EncogDirectoryPersistence.SaveObject(TrainedNetworkFile, network);
            TrainedNetworkFile = new FileInfo(TrainedNetworkFile.FullName);

            return this;
        }

        /// <see cref="INetwork.TrainNetwork"/>
        public INetwork TrainNetwork() {
            var network = (BasicNetwork) EncogDirectoryPersistence.LoadObject(TrainedNetworkFile);
            var trainingSet = EncogUtility.LoadCSV2Memory(NormalizedTrainingFile.ToString(),
                network.InputCount, network.OutputCount, true, CSVFormat.English, false);

            var train = new ResilientPropagation(network, trainingSet);
            int epoch = 1;

            do {
                train.Iteration();
                epoch++;
            } while (train.Error > Rate || epoch < MaxEpochs);

            Error = train.Error;

            EncogDirectoryPersistence.SaveObject(TrainedNetworkFile, (BasicNetwork) network);

            return this;
        }

        /// <see cref="INetwork.Evaluate"/>
        public INetwork Evaluate() {
            var network = (BasicNetwork) EncogDirectoryPersistence.LoadObject(TrainedNetworkFile);
            var analyst = new EncogAnalyst();

            analyst.Load(AnalystFile.ToString());

            var evaluationSet = EncogUtility.LoadCSV2Memory(NormalizedEvaluateFile.ToString(),
                network.InputCount, network.OutputCount, true, CSVFormat.English, false);

            int count = 0;

            using (var file = new StreamWriter(EvaluateFileOutput.ToString())) {

                file.WriteLine("Target, Predict");

                foreach (var item in evaluationSet) {
                    count++;

                    var output = network.Compute(item.Input);
                    var predict = analyst.Script.Normalize.NormalizedFields[43].DeNormalize(output[0]);
                    var target = analyst.Script.Normalize.NormalizedFields[43].DeNormalize(item.Ideal[0]);

                    PredictResult.Add(new PredictResultModel { Target = target, Predict = predict });

                    var resultLine = string.Format("{0},{1}", target, predict);
                    file.WriteLine(resultLine);
                }
            }

            return this;
        }

        /// <see cref="INetwork.BuildElmanNetwork"/>
        public INetwork BuildElmanNetwork() {
            if (TrainedNetworkFile.Exists) {
                return this;
            }

            var pattern = new ElmanPattern {
                ActivationFunction = new ActivationSigmoid(),
                InputNeurons = InputCount,
                OutputNeurons = OutputCount
            };

            pattern.AddHiddenLayer(1);

            try {
                var network = (BasicNetwork) pattern.Generate();
                EncogDirectoryPersistence.SaveObject(TrainedNetworkFile, network);
                TrainedNetworkFile = new FileInfo(TrainedNetworkFile.FullName);
            } catch (Exception e) {
                var a = e;
            }

            return this;
        }

        /// <see cref="INetwork.BuildFeedforwardNetwork"/>
        public INetwork BuildFeedforwardNetwork() {
            if (TrainedNetworkFile.Exists) {
                return this;
            }

            var pattern = new FeedForwardPattern {
                ActivationFunction = new ActivationSigmoid(),
                InputNeurons = InputCount,
                OutputNeurons = OutputCount
            };

            var network = (BasicNetwork) pattern.Generate();
            EncogDirectoryPersistence.SaveObject(TrainedNetworkFile, network);
            TrainedNetworkFile = new FileInfo(TrainedNetworkFile.FullName);

            return this;
        }

        /// <see cref="INetwork.BuildJordanNetwork"/>
        public INetwork BuildJordanNetwork() {
            if (TrainedNetworkFile.Exists) {
                return this;
            }

            var pattern = new JordanPattern {
                ActivationFunction = new ActivationSigmoid(),
                InputNeurons = InputCount,
                OutputNeurons = OutputCount
            };

            var network = (BasicNetwork) pattern.Generate();
            EncogDirectoryPersistence.SaveObject(TrainedNetworkFile, network);
            TrainedNetworkFile = new FileInfo(TrainedNetworkFile.FullName);

            return this;
        }

        #endregion

        #region Helper Methods

        private static void ConfigureNormalizedFields(EncogAnalyst analyst) {
            foreach (var field in analyst.Script.Normalize.NormalizedFields) {
                field.NormalizedHigh = 1;
                field.NormalizedLow = 0;
            }
        }

        #endregion

    }
}
