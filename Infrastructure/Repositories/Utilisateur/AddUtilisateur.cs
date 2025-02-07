
using Core.DTO.UtilisateurDTO;
using Core.UseCase;
using Core.UseCase.Utilisateur;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Services.NewFolder;
using Core.UseCase.Adresse.Abstraction;
using Core.DTO.AdresseDTO;

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
            AdresseResponse adresseResponse = null;
            if (input.AdresseCodePostal != null)
            {
                adresseResponse = await _addAdresse.ExecuteAsync(new AdresseAddRequest { CodePostal = input.AdresseCodePostal, Pays = input.AdressePays, Rue = input.AdresseRue, Ville = input.AdresseVille });
            }

            var hash = MyEncryption.Hash(input.Mdp);// HashPassword(input.Mdp);
            // Ajout de l'utilisateur
            var user = new Utilisateur { UserName = input.UserName, Email = input.Email, Mdp = hash, AdresseFk = adresseResponse == null ? null : adresseResponse.Id, Role = (int)RoleEnum.Client };
            var addUser = _dbContext.Utilisateur.Add(user);
            await _dbContext.SaveChangesAsync();

            var response = new UtilisateurResponse { UserName = addUser.Entity.UserName, Email = addUser.Entity.Email };

            return await Task.FromResult(response);
        }
    }
}
