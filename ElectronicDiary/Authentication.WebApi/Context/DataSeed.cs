using Authentication.WebApi.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.Context
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(AuthenticationContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) 
        {

            if (!roleManager.Roles.Any())
            { 
                var adminRole = await roleManager.CreateAsync(new IdentityRole("Admin"));
                var userRole = await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!userManager.Users.Any())
            {
                var admin = new AppUser() {Login = "Administrator", UserName = "Admin", Email = "admin@admin.com"};
                await userManager.CreateAsync(admin, "!23QweAsdA");
                await userManager.AddToRoleAsync(admin, "Admin");

                var user = new AppUser() { Login = "User", UserName = "User", Email = "user@user.com" };
                await userManager.CreateAsync(user, "!23QweAsdU");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}