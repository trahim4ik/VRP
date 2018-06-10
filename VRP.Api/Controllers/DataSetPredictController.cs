using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.DAL.Core;
using VRP.Entities;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class DataSetPredictController : BaseController {

        #region Variables

        private readonly IDataSetPredictService _dataSetPredictService;

        #endregion

        #region Constructor

        public DataSetPredictController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetPredictService = ServiceProvider.GetRequiredService<IDataSetPredictService>();
        }

        #endregion

        #region API

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(
                _dataSetPredictService.GetListNoTracking(
                    x => x.DataSetId == id,
                    orderBys: _dataSetPredictService.CreateOrderBys(new OrderByDescending<DataSetPredict, long>(x => x.Id)),
                    take: 100));
        }

        #endregion

    }
}
