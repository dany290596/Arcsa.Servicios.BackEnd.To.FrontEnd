using Evaluacion.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Evaluacion.Data.Interfaces.Common;
using Evaluacion.Data.Implements.Common;
using Evaluacion.Services.Interfaces.Cv;
using Evaluacion.Services.Services.Cv;

namespace Evaluacion.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EvaluacionContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Evaluacion"));
                options.EnableSensitiveDataLogging();
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IInformacionService, InformacionService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            string[] pagesApplication = { "Cv" };

            services.AddSwaggerGen(c =>
            {
                foreach (string page in pagesApplication)
                {
                    c.SwaggerDoc(page, new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = page.Replace("Evaluación", "Evaluación"),
                        Version = "v1",
                        Description = "Backend Evaluación",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "danielbr.estatus@gmail.com",
                            Name = "Daniel Benito Rosales S.A. de C.V.",
                            //Url = new Uri(""),
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "Evaluación",
                            //Url = new Uri(""),
                        }
                    });
                }

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Autenticación JWT (Bearer)",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id= "Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("V1", new OpenApiInfo { Title = "Evaluación.Api", Version = "V1" });
            });

            return services;
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Acccess-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Acccess-Control-Allow-Origin", "*");
        }
    }
}