using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class DataSetController : BaseController {

        private readonly IDataSetService _dataSetService;

        public DataSetController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _dataSetService = ServiceProvider.GetRequiredService<IDataSetService>();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(_dataSetService.GetSingleNoTracking(x => x.Id == id));
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody]SearchModel model) {
            return Ok(new SearchResult<DataSetModel> {
                Total = _dataSetService.Count(x => true),
                Items = _dataSetService.GetListNoTracking(x => true)
            });
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]DataSetModel model) {
            return Ok(_dataSetService.Create(model));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody]DataSetModel model) {
            return Ok(_dataSetService.Update(model));
        }

    }
}
