using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.Dtos;
using VRP.Dtos.Core;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class RealtyController : BaseController {

        private readonly IRealtyService _realtyService;

        public RealtyController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _realtyService = ServiceProvider.GetRequiredService<IRealtyService>();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(_realtyService.GetSingleNoTracking(x => x.Id == id));
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody]SearchModel model) {
            return Ok(new RealtiesResult {
                Total = _realtyService.Count(x => true),
                Items = _realtyService.GetListNoTracking(x => true)
            });
        }

    }
}
