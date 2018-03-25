using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VRP.Dtos;
using VRP.Services.Interfaces;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class UsersController : BaseController {

        private readonly IUserService _userService;

        public UsersController(IServiceProvider serviceProvider) : base(serviceProvider) {
            _userService = ServiceProvider.GetRequiredService<IUserService>();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            return Ok(_userService.GetSingleNoTracking(x => x.Id == id));
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody]string value) {
            return Ok(new UsersResult {
                Total = _userService.Count(x => true),
                Items = _userService.GetListNoTracking(x => true)
            });
        }

    }
}
