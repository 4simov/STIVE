using Core.DTO.AdresseDTO;
using Core.DTO.UtilisateurDTO;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using Core.UseCase.Utilisateur;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Repositories.UtilisateurNS
{
    public class UpdateUtilisateur : BaseUseCase<NegosudContext>, IUpdateUtilisateur
    {
        private readonly IAddAdresse _addAdresse;
        public UpdateUtilisateur(NegosudContext context, IAddAdresse addAdresse) : base(context)
        {
            _addAdresse = addAdresse;
            //_userTokenService = userTokenService;
        }

        public async Task<UtilisateurResponse> ExecuteAsync(UtilisateurUpdateRequest input)
        {
            
            var utilisateur = _dbContext.Utilisateur.FirstOrDefault( u => u.Id.ToString() == input.Id);

            if (utilisateur == null) 
            {
                throw new KeyNotFoundException($"L'utilisateur n'a pas été trouvée ou vous n'avez pas les droits de le modifier.");
            }

            utilisateur.UserName = input.UserName ?? utilisateur.UserName;
            utilisateur.Email = input.Email ?? utilisateur.Email;

            if (utilisateur.Adresse != null)
            {
                utilisateur.Adresse.Rue = input.AdresseRue ?? utilisateur.Adresse.Rue;
                utilisateur.Adresse.CodePostal = input.AdresseCodePostal ?? utilisateur.Adresse.CodePostal;
                utilisateur.Adresse.Pays = input.AdressePays ?? utilisateur.Adresse.Pays;
                utilisateur.Adresse.Ville = input.AdresseVille ?? utilisateur.Adresse.Ville;
            }
            else if(utilisateur.Adresse == null && input.AdresseRue != null && input.AdresseCodePostal != null && input.AdressePays != null && input.AdresseVille != null)
            {
                var adresse = await _addAdresse.ExecuteAsync( new AdresseAddRequest { 
                    CodePostal = input.AdresseCodePostal, 
                    Pays = input.AdressePays, 
                    Rue = input.AdresseRue, 
                    Ville = input.AdresseVille 
                });
                utilisateur.AdresseFk = adresse.Id;
            }

            _dbContext.Update(utilisateur);
            _dbContext.SaveChanges();

            return await Task.FromResult(new UtilisateurResponse
            {
                Email = utilisateur.Email,
                UserName = utilisateur.UserName,
            });
        }
    }
}
