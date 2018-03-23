using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using VRP.Core.Constants;
using VRP.Entities;

namespace VRP.DAL {

    public static class DbInitializer {

        public static void Initialize(IServiceProvider serviceProvider) {

            CreateRoles(serviceProvider);

            CreateUsers(serviceProvider);

        }

        private static void CreateRoles(IServiceProvider serviceProvider) {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            foreach (var role in Roles.AllRoles) {
                if (!roleManager.RoleExistsAsync(role).Result) {
                    roleManager.CreateAsync(new Role { Name = role, Description = $"The base {role} role." }).Wait();
                }
            }
        }

        private static void CreateUsers(IServiceProvider serviceProvider) {
            var user = "vladsqil@gmail.com";
            var password = "Test1234";

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            if (userManager.FindByNameAsync(user).Result != null) return;

            userManager.CreateAsync(new User { UserName = user, Email = user, EmailConfirmed = true }, password).Wait();

            var admin = userManager.FindByNameAsync(user).Result;
            userManager.AddToRoleAsync(admin, Roles.Administrator).Wait();
        }
    }
}
