
using Core.DTO.Utilisateur;
using Core.DTO.Adresse;
using Core.UseCase;
using Core.UseCase.Utilisateur;
using Domain.Entities;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;
using Domain.Enums;
using System.Security.Cryptography;
using System.Text;
using Infrastructure.Services.NewFolder;
using Core.UseCase.Adresse.Abstraction;

namespace Infrastructure.Repositories.UtilisateurNS
{
    public class AddUtilisateur : BaseUseCase<NegosudContext>, IAddUtilisateur
    {
        private readonly IAddAdresse _addAdresse;
        public AddUtilisateur(NegosudContext context, IAddAdresse addAdresse) : base(context)
        {
            _addAdresse = addAdresse;
        }

        public async Task<UtilisateurResponse> ExecuteAsync(UtilisateurAddRequest input)
        {
            // Ajout de l'adresse
            //var adresse = new Adresse { CodePostal = input.AdresseCodePostal, Pays = input.AdressePays, Rue = input.AdresseRue, Ville = input.AdresseVille };
            //var addAdresse = _dbContext.Adresse.Add(adresse);
            //await _dbContext.SaveChangesAsync();
            var adresseResponse = await _addAdresse.ExecuteAsync(new AdresseAddRequest { CodePostal = input.AdresseCodePostal, Pays = input.AdressePays, Rue = input.AdresseRue, Ville = input.AdresseVille });

            var hash = MyEncryption.Hash(input.Mdp);// HashPassword(input.Mdp);
            // Ajout de l'utilisateur
            var user = new Utilisateur { UserName = input.UserName, Email = input.Email, Mdp = hash, AdresseFk = adresseResponse.Id, Role = input.Role == 0 ? (int)RoleEnum.Client : input.Role };
            var addUser = _dbContext.Utilisateur.Add(user);
            await _dbContext.SaveChangesAsync();

            var response = new UtilisateurResponse { UserName = addUser.Entity.UserName, Email = addUser.Entity.Email };

            return await Task.FromResult(response);
        }
    }
}
