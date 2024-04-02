using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // gli indico l'assembly dove sono presenti i validatori 
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                    SingleOrDefault(assembly => assembly.GetName().Name == "Paradigmi.Libreria.Application")
                );
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            return services;
        }
    }
}
