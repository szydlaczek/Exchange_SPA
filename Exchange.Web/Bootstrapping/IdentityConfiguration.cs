using Exchange.Domain.Entities;
using Exchange.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Web.Bootstrapping
{
    internal static class IdentityConfiguration
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services
                .AddSingleton<IRoleStore<Role>, CustomRoleStore>()
                .AddSingleton<CustomRoleStore>()
                .AddSingleton<IUserStore<User>, CustomUserStore>();
                

            services.AddIdentity<User, Role>(ConfigureIdentityOptions)
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.ExpireTimeSpan = TimeSpan.FromDays(30));

            return services;
        }

        private static void ConfigureIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    }
}
