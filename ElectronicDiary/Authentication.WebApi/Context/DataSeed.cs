using Authentication.WebApi.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.Context
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(AuthenticationContext context, UserManager<AppUser> userManager)
        {
            var users2 = userManager.Users;
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                                {
                                    new AppUser
                                        {
                                            Login = "Administrator",
                                            UserName = "Admin",
                                            Email = "admin@admin.com"
                                        },

                                    new AppUser
                                        {
                                            Login = "User",
                                            UserName = "User",
                                            Email = "user@user.com"
                                        }
                                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "!23QweAsd");
                }

            }
        }
    }
}