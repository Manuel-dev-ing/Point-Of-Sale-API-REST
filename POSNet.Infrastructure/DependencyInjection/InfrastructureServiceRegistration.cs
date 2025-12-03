using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNet.Infrastructure.Repositories;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<POSNetDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICategoryRepository, CategorieRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IProveedoresRepository, ProveedoresRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IVentasRepository, VentasRepository>();
            services.AddScoped<IComprasRepository, ComprasRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }


    }
}
