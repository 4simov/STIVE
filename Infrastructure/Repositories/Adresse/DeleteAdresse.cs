using System;
using System.Threading.Tasks;
using Core.DTO.Adresse;
using Core.UseCase.Adresse.Abstraction;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.Adresse
{
    public class DeleteAdresse : IDeleteAdresse, IUseCaseProcess<int, AdresseResponse>
    {
        private readonly NegosudContext _context;

        public DeleteAdresse(NegosudContext context)
        {
            _context = context;
        }

        async Task<AdresseResponse> IUseCaseProcess<int, AdresseResponse>.ExecuteAsync(int id)
        {
            // Rechercher l'adresse par son ID
            var adresseToDelete = await _context.Adresse.FirstOrDefaultAsync(a => a.Id == id);

            if (adresseToDelete == null)
            {
                throw new KeyNotFoundException($"Adresse avec l'ID {id} n'a pas été trouvée.");
            }

            // Supprimer l'adresse
            _context.Adresse.Remove(adresseToDelete);

            // Sauvegarder les changements
            await _context.SaveChangesAsync();

            // Retourne une réponse après suppression
            return new AdresseResponse
            {
                Id = adresseToDelete.Id,
                Pays = adresseToDelete.Pays,
                Rue = adresseToDelete.Rue,
                Ville = adresseToDelete.Ville,
                CodePostal = adresseToDelete.CodePostal
            };
        }
    }
}
