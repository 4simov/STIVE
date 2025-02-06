using Core.DTO.FournisseurDTO;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var fournisseurToUpdate = await _dbContext.Fournisseur.FirstOrDefaultAsync(a => a.Id == input.Id);
            

            if (fournisseurToUpdate == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {input.Id} n'a pas été trouvée.");
            }

            // Met à jour les champs de l'adresse
            fournisseurToUpdate.Nom = input.Nom ?? fournisseurToUpdate.Nom;

            var findFournisseurAdresseToUpdate = await _dbContext.Adresse.FirstOrDefaultAsync(a => a.Id == input.AdresseFK);

            if (findFournisseurAdresseToUpdate == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {input.AdresseFK} n'a pas été trouvée.");
            }

            findFournisseurAdresseToUpdate.Pays = input.Pays ?? findFournisseurAdresseToUpdate.Pays;
            findFournisseurAdresseToUpdate.Rue = input.Rue ?? findFournisseurAdresseToUpdate.Rue;
            findFournisseurAdresseToUpdate.Ville = input.Ville ?? findFournisseurAdresseToUpdate.Ville;
            findFournisseurAdresseToUpdate.CodePostal = input.CodePostal ?? findFournisseurAdresseToUpdate.CodePostal;

            // Sauvegarde les changements
            _dbContext.Fournisseur.Update(fournisseurToUpdate);
            await _dbContext.SaveChangesAsync();

            // Retourne la réponse
            return new FournisseurResponse
            {
                Id = fournisseurToUpdate.Id,
                Nom = fournisseurToUpdate.Nom,
                Adresse = findFournisseurAdresseToUpdate,

            };
        }
    }
}
