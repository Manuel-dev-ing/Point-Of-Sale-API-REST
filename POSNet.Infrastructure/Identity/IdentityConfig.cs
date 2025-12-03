using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POSNet.Infrastructure.Identity.Stores;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Identity
{
    public static class IdentityConfig
    {
        public static void AddIdentityDatabaseFirst(this IServiceCollection services)
        {
            services.AddIdentityCore<Usuario>(options =>
            {

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;

            })
            .AddSignInManager();

            //services.AddScoped<IUserStore<Usuario>, Usuario>();
            services.AddScoped<IUserStore<Usuario>, UsuarioStore>();

        }



    }
}
