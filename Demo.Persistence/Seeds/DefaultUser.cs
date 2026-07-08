using Demo.Application.Enums;
using Demo.Persistence.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Persistence.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser();
            user.UserName = "superadmin";
            user.Email = "superadmin@example.com";
            user.FirstName = "Super";
            user.LastName = "Admin";
            user.Gender = "Female";
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;

            if(userManager.Users.All(u => u.Id != user.Id))
            {
               var result = await userManager.FindByEmailAsync(user.Email);
               if(result == null)
               {
                   await userManager.CreateAsync(user, "SuperAdmin123!");
                   await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                   await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                   await userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                }
            }
        }
    }
}
