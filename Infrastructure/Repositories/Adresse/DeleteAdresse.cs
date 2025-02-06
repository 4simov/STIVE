using Core.DTO.AdresseDTO;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase;

namespace Infrastructure.Repositories.AdresseNS
{
    public class DeleteAdresse : BaseUseCase<NegosudContext>, IDeleteAdresse, IUseCaseProcess<int, AdresseResponse>
    {
        public DeleteAdresse(NegosudContext context) : base(context)
        {
        }

        async Task<AdresseResponse> IUseCaseProcess<int, AdresseResponse>.ExecuteAsync(int id)
        {
            // Rechercher l'adresse par son ID
            var adresseToDelete = await _dbContext.Adresse.FirstOrDefaultAsync(a => a.Id == id);

            if (adresseToDelete == null)
            {
                throw new KeyNotFoundException($"Adresse avec l'ID {id} n'a pas été trouvée.");
            }

            // Supprimer l'adresse
            _dbContext.Adresse.Remove(adresseToDelete);

            // Sauvegarder les changements
            await _dbContext.SaveChangesAsync();

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
