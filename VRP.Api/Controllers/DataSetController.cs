using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VRP.Api.Extensions;
using VRP.Core.Enums;
using VRP.Core.Options;
using VRP.DAL.Core;
using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Entities;
using VRP.NeuronNetwork;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class DataSetController : BaseController {

        #region Variables

        private readonly IDataSetService _dataSetService;
        private readonly IDataSetItemService _dataSetItemService;
        private readonly IDataSetParser _parser;
        private readonly IOptions<FileSystemOptions> _fileSystemOptions;
        private readonly IFileHandlerService _fileHandlerService;
        private readonly IDataSetFileEntryService _dataSetFileEntryService;
        private readonly IDataSetNetworkService _dataSetNetworkService;
        private readonly IDataSetPredictService _dataSetPredictService;
        private readonly IFileEntryService _fileEntryService;
        private readonly INetwork _network;

        #endregion

        #region Constructor

        public DataSetController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetService = ServiceProvider.GetRequiredService<IDataSetService>();
            _dataSetItemService = ServiceProvider.GetRequiredService<IDataSetItemService>();
            _dataSetFileEntryService = ServiceProvider.GetRequiredService<IDataSetFileEntryService>();
            _fileSystemOptions = ServiceProvider.GetRequiredService<IOptions<FileSystemOptions>>();
            _parser = ServiceProvider.GetRequiredService<IDataSetParser>();
            _fileHandlerService = ServiceProvider.GetRequiredService<IFileHandlerService>();
            _network = ServiceProvider.GetRequiredService<INetwork>();
            _dataSetNetworkService = ServiceProvider.GetRequiredService<IDataSetNetworkService>();
            _fileEntryService = ServiceProvider.GetRequiredService<IFileEntryService>();
            _dataSetPredictService = ServiceProvider.GetRequiredService<IDataSetPredictService>();
        }

        #endregion

        #region API

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var includes = _dataSetService.CreateIncludes(x => x.DataSetFileEntries.Select(y => y.FileEntry));
            return Ok(_dataSetService.GetSingleNoTracking(x => x.Id == id, includes));
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody]SearchModel model) {
            return Ok(_dataSetService.Search(model));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]DataSetModel model) {
            model.UserId = User.GetId();
            return Ok(_dataSetService.Create(model));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody]DataSetModel model) {
            return Ok(_dataSetService.Update(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok(_dataSetService.Delete(x => x.Id == id));
        }

        [HttpPost]
        [Route("Train/{id}")]
        public async Task<IActionResult> Train([FromRoute] long id, IFormFile file) {
            if (file == null) {
                throw new ArgumentNullException(nameof(file));
            }

            if (id == 0) {
                throw new ArgumentException(nameof(id));
            }

            var datasetNetwork = _dataSetNetworkService.GetSingleNoTracking(x => x.DataSetId == id && x.DeleteDate == null, includes: _dataSetNetworkService.CreateIncludes(x => x.FileEntry));

            var fileEntry = await _fileHandlerService.Upload(file);
            _dataSetFileEntryService.Create(new DataSetFileEntryModel { FileEntryId = fileEntry.Id, DataSetId = id, DataSetType = DataSetType.Train });

            var sourceFilePath = Path.Combine(_fileSystemOptions.Value.Content, fileEntry.Name);
            var sourceFile = new FileInfo(sourceFilePath);
            var filename = Path.GetFileNameWithoutExtension(sourceFilePath);

            var network = new Network {
                BaseFile = new FileInfo(sourceFilePath),
                ShuffledFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ filename }.shuffled.csv")),
                TrainingFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ filename }.training.csv")),
                EvaluateFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ filename }.evaluate.csv")),
                NormalizedTrainingFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{filename}.normalized.training.csv")),
                NormalizedEvaluateFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{filename}.normalized.evaluate.csv")),
                AnalystFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{filename}.analyst.ega")),
                EvaluateFileOutput = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{filename}.evaluate.out.csv")),
                TrainedNetworkFile = new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, datasetNetwork == null ? $"{Guid.NewGuid().ToString()}.eg" : datasetNetwork.FileEntry.Name))
            };

            network
                .Shuffle()
                .Segregate()
                .Normalize()
                .CreateNetwork()
                .TrainNetwork()
                .Evaluate();

            _dataSetNetworkService.Update(x => x.DataSetId == id && x.DeleteDate == null, action: x => x.DeleteDate = DateTime.UtcNow);
            datasetNetwork = _dataSetNetworkService.Create(new DataSetNetworkModel {
                FileEntry = new FileEntryModel {
                    Extension = network.TrainedNetworkFile.Extension,
                    FileName = network.TrainedNetworkFile.Name,
                    Name = network.TrainedNetworkFile.Name,
                    Length = network.TrainedNetworkFile.Length,
                    Description = "The current dataset network state."
                },
                Error = network.Error,
                DataSetId = id
            });

            var dataSetPredicts = network.PredictResult.Select(x => new DataSetPredictModel { DataSetId = id, Predict = x.Predict, Target = x.Target }).ToList();
            _dataSetPredictService.CreateBulk(dataSetPredicts);

            var dataSetItems = _parser.Parse(sourceFilePath);
            dataSetItems = _dataSetItemService.Create(dataSetItems.Select(x => {
                x.InsertDate = DateTime.UtcNow;
                return x;
            }).ToList(), id);

            return Ok(new {
                FileEntry = fileEntry,

                DataSetItemModels = dataSetItems.Take(100),

                DataSetNetworks = _dataSetNetworkService.GetListNoTracking(
                    x => x.DataSetId == id,
                    orderBys: _dataSetNetworkService.CreateOrderBys(new OrderByDescending<DataSetNetwork, long>(x => x.Id)),
                    includes: _dataSetNetworkService.CreateIncludes(x => x.FileEntry)).Take(1000),

                DataSetPredicts = _dataSetPredictService.GetListNoTracking(
                    x => x.DataSetId == id,
                    orderBys: _dataSetPredictService.CreateOrderBys(new OrderByDescending<DataSetPredict, long>(x => x.Id))).Take(1000),

            });
        }

        [HttpGet("Download/{id}")]
        public IActionResult Download(long id) {

            var filename = _fileEntryService.GetSingleNoTracking(x => x.Id == id, select: x => x.Name);
            var name = Path.GetFileNameWithoutExtension(filename);

            var files = new List<FileInfo> {
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, filename)),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ name }.shuffled.csv")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ name }.training.csv")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{ name }.evaluate.csv")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{name}.normalized.training.csv")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{name}.normalized.evaluate.csv")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{name}.analyst.ega")),
                new FileInfo(Path.Combine(_fileSystemOptions.Value.Content, $"{name}.evaluate.out.csv")),
            };
            using (var memoryStream = new MemoryStream()) {

                using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {

                    foreach (var file in files) {
                        if (file.Exists) {
                            ziparchive.CreateEntryFromFile(file.FullName, file.Name);
                        }
                    }

                }

                return File(memoryStream.ToArray(), "application/zip", $"{name}.zip");
            }
        }

        #endregion

    }
}
