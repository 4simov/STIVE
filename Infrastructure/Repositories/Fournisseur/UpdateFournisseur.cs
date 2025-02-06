using Core.DTO.FournisseurDTO;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UseCase.Adresse.Abstraction;
using Infrastructure.Repositories.AdresseNS;
using Core.DTO.AdresseDTO;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class UpdateFournisseur : BaseUseCase<NegosudContext>, IUpdateFournisseur
    {
        private readonly IAddAdresse _addAdresse;
        public UpdateFournisseur(NegosudContext context, IAddAdresse addAdresse) : base(context)
        {
            _addAdresse = addAdresse;
        }

        public async Task<FournisseurResponse> ExecuteAsync(FournisseurUpdateRequest input)
        {
            // Vérifie si l'adresse existe
            var fournisseurToUpdate = await _dbContext.Fournisseur.Include(f => f.Adresse).FirstOrDefaultAsync(a => a.Id == input.Id);
            

            if (fournisseurToUpdate == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {input.Id} n'a pas été trouvée.");
            }

            // Met à jour les champs de l'adresse
            fournisseurToUpdate.Nom = input.Nom ?? fournisseurToUpdate.Nom;

            if (fournisseurToUpdate.Adresse == null)
            {
                if (input.Pays != null && input.Ville != null && input.CodePostal != null && input.Rue != null)
                {
                    var adressToAdd = await _addAdresse.ExecuteAsync(new AdresseAddRequest { Pays = input.Pays, Ville = input.Ville, CodePostal = input.CodePostal, Rue = input.Rue });
                    fournisseurToUpdate.AdresseId = adressToAdd.Id;
                }
                else
                {
                    throw new KeyNotFoundException($"Il manque des éléments dans la requête pour créer l'adresse.");
                }
            }
            else
            {
                fournisseurToUpdate.Adresse.Pays = input.Pays ?? fournisseurToUpdate.Adresse.Pays;
                fournisseurToUpdate.Adresse.Rue = input.Rue ?? fournisseurToUpdate.Adresse.Rue;
                fournisseurToUpdate.Adresse.Ville = input.Ville ?? fournisseurToUpdate.Adresse.Ville;
                fournisseurToUpdate.Adresse.CodePostal = input.CodePostal ?? fournisseurToUpdate.Adresse.CodePostal;
            }

            // Sauvegarde les changements
            _dbContext.Fournisseur.Update(fournisseurToUpdate);
            await _dbContext.SaveChangesAsync();

            // Retourne la réponse
            return new FournisseurResponse
            {
                Id = fournisseurToUpdate.Id,
                Nom = fournisseurToUpdate.Nom,
                Adresse = fournisseurToUpdate.Adresse,

            };
        }
    }
}
