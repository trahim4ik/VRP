using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class DataSetItemController : BaseController {

        private readonly IDataSetItemService _dataSetItemService;

        public DataSetItemController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetItemService = ServiceProvider.GetRequiredService<IDataSetItemService>();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(_dataSetItemService.GetSingleNoTracking(x => x.Id == id));
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody]SearchModel model) {
            return Ok(new SearchResult<DataSetItemModel> {
                Total = _dataSetItemService.Count(x => true),
                Items = _dataSetItemService.GetListNoTracking(x => true)
            });
        }

    }
}
