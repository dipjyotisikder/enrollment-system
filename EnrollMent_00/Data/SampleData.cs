using EnrollMent_00.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollMent_00.Data
{
    public class SampleData
    {

        public static async Task InitializeData(IServiceProvider service, ApplicationDbContext context)
        {

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = {"Admin", "Student", "UnAuthorized"};
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if(!roleExists)
                {
                    roleResult = await roleManager.CreateAsync( new IdentityRole (roleName));
                }
            }
            var _userManager = service.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName = "mdnazmussakibcse@gmail.com",
                Email = "mdnazmussakibcse@gmail.com"
            };

            var result = await _userManager.CreateAsync(user, "Passw0rd!");
            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
