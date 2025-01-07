﻿using STIVE.Core.UseCase.Famille.Abstraction;
using Core.UseCase.Famille.Abstraction;
using Core.UseCase.Adresse.Abstraction;
using Core.UseCase.Utilisateur;
using Infrastructure.Repositories.AdresseNS;
using Infrastructure.Repositories.FamilleNS;
using Infrastructure.Repositories.UtilisateurNS;
using Infrastructure.Services.Jwt;
using Core.Services.Token;
using STIVE.Infrastructure;
using Infrastructure.Repositories.FournisseurNS;
using Core.UseCase.Fournisseur;

namespace Infrastructure.Services.Token
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

            services.AddScoped<IAddFournisseur, AddFournisseur>();
            services.AddScoped<IGetFournisseur, GetFournisseur>();
            services.AddScoped<IDeleteFournisseur, DeleteFournisseur>();
            services.AddScoped<IUpdateFournisseur, UpdateFournisseur>();

            services.AddScoped<ITokenGenerator, MyJwt>();

            services.AddScoped<IAddUtilisateur, AddUtilisateur>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IResetPassword, ResetPassword>();

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
