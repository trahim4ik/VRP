using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VRP.Api.Extensions;
using VRP.Core.Enums;
using VRP.Core.Options;
using VRP.Dtos;
using VRP.Dtos.Core;
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

        [HttpPost]
        [Route("TrainNetwork/{id}")]
        public IActionResult TrainNetwork([FromRoute] long id) {
            return Ok(_dataSetFileEntryService.GetList(x => x.DataSetId == id, select: x => x.DataSet)
                .ToList());
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

            var fileEntry = await _fileHandlerService.Upload(file);
            _dataSetFileEntryService.Create(new DataSetFileEntryModel {
                FileEntryId = fileEntry.Id,
                DataSetId = id,
                DataSetType = DataSetType.Train
            });

            var filePath = Path.Combine(_fileSystemOptions.Value.Content, fileEntry.Name);
            _network.Train(filePath);
            var dataSetItems = _parser.Parse(filePath);
            dataSetItems = _dataSetItemService.Create(dataSetItems.ToList(), id);

            return Ok(new { FileEntry = fileEntry, DataSetItemModels = dataSetItems.Take(100) });
        }

        [HttpPost]
        [Route("Test/{id}")]
        public async Task<IActionResult> Test([FromRoute] long id, IFormFile file) {
            if (file == null) {
                throw new ArgumentNullException(nameof(file));
            }

            var fileEntry = await _fileHandlerService.Upload(file);
            _dataSetFileEntryService.Create(new DataSetFileEntryModel {
                FileEntryId = fileEntry.Id,
                DataSetId = id,
                DataSetType = DataSetType.Test
            });

            var filePath = Path.Combine(_fileSystemOptions.Value.Content, fileEntry.Name);
            var dataSetItems = _parser.Parse(filePath);

            dataSetItems = _dataSetItemService.Create(dataSetItems.ToList(), id, DataSetType.Test);

            return Ok(new { FileEntry = fileEntry, DataSetItemModels = dataSetItems.Take(100) });
        }

        #endregion

    }
}
