using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UseCase.Fournisseur;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class UpdateFournisseur : BaseUseCase<NegosudContext>, IUpdateFournisseur
    {
        public UpdateFournisseur(NegosudContext context) : base(context)
        {
        }

        public async Task<FournisseurResponse> ExecuteAsync(FournisseurUpdateRequest input)
        {
            // Vérifie si l'adresse existe
            var adresseToUpdate = await _dbContext.Fournisseur.FirstOrDefaultAsync(a => a.Id == input.Id);

            if (adresseToUpdate == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {input.Id} n'a pas été trouvée.");
            }

            // Met à jour les champs de l'adresse
            adresseToUpdate.Nom = input.Nom ?? adresseToUpdate.Nom;
            adresseToUpdate.AdresseFk = input.AdresseFK;

            // Sauvegarde les changements
            _dbContext.Fournisseur.Update(adresseToUpdate);
            await _dbContext.SaveChangesAsync();

            // Retourne la réponse
            return new FournisseurResponse
            {
                Id = adresseToUpdate.Id,
                Nom = adresseToUpdate.Nom,
                AdresseFK = adresseToUpdate.AdresseFk,
            };
        }
    }
}
