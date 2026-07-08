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
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var role = new ApplicationRole();
            role.Name = Roles.SuperAdmin.ToString();
            role.NormalizedName = role.Name.ToUpper();
            await roleManager.CreateAsync(role);

            var role2 = new ApplicationRole();
            role2.Name = Roles.Admin.ToString();
            role2.NormalizedName = role2.Name.ToUpper();
            await roleManager.CreateAsync(role2);

            var role3 = new ApplicationRole();
            role3.Name = Roles.Basic.ToString();
            role3.NormalizedName = role3.Name.ToUpper();
            await roleManager.CreateAsync(role3);

            var role4 = new ApplicationRole();
            role4.Name = Roles.User.ToString();
            role4.NormalizedName = role4.Name.ToUpper();
            await roleManager.CreateAsync(role4);
        }
    }
}
