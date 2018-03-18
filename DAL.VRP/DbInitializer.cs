using Microsoft.AspNetCore.Identity;
using VRP.Core.Constants;
using VRP.DAL.Interfaces;
using VRP.Entities;

namespace VRP.DAL {

    public class DbInitializer : IDbInitializer {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize() {

            CreateRoles();

            CreateUsers();

        }

        private async void CreateRoles() {
            foreach (var role in Roles.AllRoles) {
                if (!await _roleManager.RoleExistsAsync(role)) {
                    await _roleManager.CreateAsync(new Role { Name = role, Description = $"The base {role} role." });
                }
            }
        }

        private async void CreateUsers() {
            string user = "vladsqil@gmail.com";
            string password = "Test1234";

            if (await _userManager.FindByNameAsync(user) != null) return;

            await _userManager.CreateAsync(new User { UserName = user, Email = user, EmailConfirmed = true }, password);
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), Roles.Administrator);
        }
    }
}
