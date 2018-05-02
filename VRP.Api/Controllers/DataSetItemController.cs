using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.Core.Enums;
using VRP.DAL.Core;
using VRP.Entities;
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

        [HttpGet("Train/{dataSetId}")]
        public IActionResult Train([FromRoute]long dataSetId) {
            return Ok(_dataSetItemService.GetListNoTracking(
                x => x.DataSetId == dataSetId && x.DataSetType == DataSetType.Train,
                orderBys: _dataSetItemService.CreateOrderBys(new OrderByDescending<DataSetItem, long>(x => x.Id)),
                take: 100));
        }

        [HttpGet("Test/{dataSetId}")]
        public IActionResult Test([FromRoute]long dataSetId) {
            return Ok(_dataSetItemService.GetListNoTracking(
                x => x.DataSetId == dataSetId && x.DataSetType == DataSetType.Test,
                orderBys: _dataSetItemService.CreateOrderBys(new OrderByDescending<DataSetItem, long>(x => x.Id)),
                take: 100));
        }

    }
}
