using Demo.Application.Interfaces;
using Demo.Persistence.Data;
using Demo.Persistence.IdentityModels;
using Demo.Persistence.Seeds;
using Demo.Persistence.SharedServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddDataProtection();
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IAccountService, AccountService>();

        }
    }
}
