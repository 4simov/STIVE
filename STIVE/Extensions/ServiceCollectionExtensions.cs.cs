using Core.DTO.Famille;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille;
using STIVE.Core.UseCase;
using STIVE.Infrastructure;
using Core.UseCase.Famille.Abstraction;
using STIVE.Infrastructure.Repositories;

namespace STIVE.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Enregistrement des UseCases
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetFamille, GetFamille>();
            services.AddScoped<IAddFamille, AddFamille>();
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
