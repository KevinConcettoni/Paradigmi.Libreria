using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using Paradigmi.Libreria.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<IUtenteRepository, UtenteRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            return services;
        }
    }
}
