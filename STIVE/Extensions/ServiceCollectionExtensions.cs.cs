using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille;
using STIVE.Infrastructure;
using Core.UseCase.Famille.Abstraction;
using STIVE.Infrastructure.Repositories;
using Core.UseCase.Adresse.Abstraction;
using Infrastructure.Repositories.Adresse;

namespace STIVE.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Enregistrement des UseCases
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetFamille, UpdateFamille>();
            services.AddScoped<IAddFamille, AddFamille>();

            services.AddScoped<IAddAdresse, AddAdresse>();
            services.AddScoped<IGetAdresse, GetAdresse>();
            services.AddScoped<IDeleteAdresse, DeleteAdresse>();
            services.AddScoped<IUpdateAdresse, UpdateAdresse>();

            return services;
        }

        // Enregistrement des Repositories ou accès à la couche Infrastructure
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<NegosudContext>(); // Exemple d'enregistrement pour votre DbContext
            return services;
        }

        // Autres services comme les services métiers
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Exemple si vous avez des services métiers
            return services;
        }
    }
}
