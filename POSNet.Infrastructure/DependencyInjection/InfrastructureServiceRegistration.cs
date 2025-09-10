using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSNet.Application.Interfaces;
using POSNet.Infrastructure.Persistence;
using POSNet.Infrastructure.Repositories;

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

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }


    }
}
