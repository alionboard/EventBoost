using EventBoost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Data
{
    //http://www.binaryintellect.net/articles/5e180dfa-4438-45d8-ac78-c7cc11735791.aspx

    public static class ApplicationDbContextSeeder
    {
        public async static Task SeedRolesAndUsersAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var roleName = "admin";
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var userName = "admin@microsoft.com";
            if (!await userManager.Users.AnyAsync(x => x.UserName == "admin@microsoft.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User"
                };

                await userManager.CreateAsync(user, "Ankara1.");
                await userManager.AddToRoleAsync(user, roleName);
            }

        }
    }
}
