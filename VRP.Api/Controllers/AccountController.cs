using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VRP.Dtos;
using VRP.Entities;

namespace VRP.Api.Controllers {
    [Route("api/[controller]")]
    public class AccountController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (ModelState.IsValid) {
                var user = new User { };
                var result = await _userManager.CreateAsync(user, "");
                if (result.Succeeded) {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok("Registred");
                }
            }
            return View(model);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName: model.Email,
                password: model.Password,
                isPersistent: true,
                lockoutOnFailure: true
            );

            if (result.RequiresTwoFactor) {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }

            if (result.IsLockedOut) {
                return StatusCode(StatusCodes.Status423Locked);
            }

            if (result.Succeeded) {
                return Ok(StatusCodes.Status200OK);
            }

            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut() {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
