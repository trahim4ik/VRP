using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.DAL.Core;
using VRP.Entities;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class DataSetNetworkController : BaseController {

        #region Variables

        private readonly IDataSetNetworkService _dataSetNetworkService;

        #endregion

        #region Constructor

        public DataSetNetworkController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetNetworkService = ServiceProvider.GetRequiredService<IDataSetNetworkService>();
        }

        #endregion

        #region API

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(_dataSetNetworkService.GetListNoTracking(
                x => x.DataSetId == id,
                includes: _dataSetNetworkService.CreateIncludes(x => x.FileEntry),
                orderBys: _dataSetNetworkService.CreateOrderBys(new OrderByDescending<DataSetNetwork, long>(x => x.Id)),
                take: 100));
        }

        #endregion

    }
}
