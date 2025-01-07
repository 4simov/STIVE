using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UseCase.Fournisseur;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class DeleteFournisseur : BaseUseCase<NegosudContext>, IDeleteFournisseur, IUseCaseProcess<int, FournisseurResponse>
    {
        public DeleteFournisseur(NegosudContext context) : base(context)
        {
        }

        async Task<FournisseurResponse> IUseCaseProcess<int, FournisseurResponse>.ExecuteAsync(int id)
        {
            // Rechercher l'adresse par son ID
            var adresseToDelete = await _dbContext.Fournisseur.FirstOrDefaultAsync(a => a.Id == id);

            if (adresseToDelete == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {id} n'a pas été trouvée.");
            }

            // Supprimer l'adresse
            _dbContext.Fournisseur.Remove(adresseToDelete);

            // Sauvegarder les changements
            await _dbContext.SaveChangesAsync();

            // Retourne une réponse après suppression
            return new FournisseurResponse
            {
                Id = adresseToDelete.Id,
                Nom = adresseToDelete.Nom,
                AdresseFK = adresseToDelete.AdresseId
            };
        }
    }
}
