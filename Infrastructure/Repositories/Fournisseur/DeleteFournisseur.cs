using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class DeleteFournisseur : BaseUseCase<NegosudContext>, IDeleteFournisseur, IUseCaseProcess<int, FournisseurResponse>
    {
        public DeleteFournisseur(NegosudContext context) : base(context)
        {
        }

        async Task<FournisseurResponse> IUseCaseProcess<int, FournisseurResponse>.ExecuteAsync(int id)
        {
            var fournisseur = await _dbContext.Fournisseur.FirstOrDefaultAsync(a => a.Id == id);
            if (fournisseur == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {id} n'a pas été trouvée.");
            }
            // Rechercher l'adresse par son ID
            var adresseToDelete = _dbContext.Adresse.FirstOrDefault(a => a.Id == fournisseur.AdresseId);
                
            if (adresseToDelete == null)
            {
                throw new KeyNotFoundException($"L'adresse avec l'ID {fournisseur.AdresseId} n'a pas été trouvée.");
            }

            // Suppression de l'adresse
            _dbContext.Adresse.Remove(adresseToDelete);

            // Suppression du fournisseur
            _dbContext.Fournisseur.Remove(fournisseur);

            // Sauvegarder les changements
            await _dbContext.SaveChangesAsync();

            // Retourne une réponse après suppression
            return new FournisseurResponse
            {
                Id = fournisseur.Id,
                Nom = fournisseur.Nom,
                AdresseId = adresseToDelete.Id
            };
        }
    }
}
