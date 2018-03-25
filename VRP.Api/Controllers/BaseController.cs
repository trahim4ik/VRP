using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VRP.Api.Controllers {
    //[Authorize]
    public abstract class BaseController : Controller {

        protected IServiceProvider ServiceProvider;

        protected BaseController(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider;
        }

    }
}
