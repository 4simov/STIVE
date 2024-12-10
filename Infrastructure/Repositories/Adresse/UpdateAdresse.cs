using Core.DTO.Adresse;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using Microsoft.EntityFrameworkCore;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.Adresse
{
    public class UpdateAdresse : BaseUseCase, IUpdateAdresse
    {
        private readonly NegosudContext _context;

        public UpdateAdresse(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AdresseResponse> ExecuteAsync(AdresseAddRequest input)
        {
            // Vérifie si l'adresse existe
            var adresseToUpdate = await _context.Adresse.FirstOrDefaultAsync(a => a.Id == input.Id);

            if (adresseToUpdate == null)
            {
                throw new KeyNotFoundException($"Adresse avec l'ID {input.Id} n'a pas été trouvée.");
            }

            // Met à jour les champs de l'adresse
            adresseToUpdate.Pays = input.Pays ?? adresseToUpdate.Pays;
            adresseToUpdate.Rue = input.Rue ?? adresseToUpdate.Rue;
            adresseToUpdate.Ville = input.Ville ?? adresseToUpdate.Ville;
            adresseToUpdate.CodePostal = input.CodePostal != default ? input.CodePostal : adresseToUpdate.CodePostal;

            // Sauvegarde les changements
            _context.Adresse.Update(adresseToUpdate);
            await _context.SaveChangesAsync();

            // Retourne la réponse
            return new AdresseResponse
            {
                Id = adresseToUpdate.Id,
                Pays = adresseToUpdate.Pays,
                Rue = adresseToUpdate.Rue,
                Ville = adresseToUpdate.Ville,
                CodePostal = adresseToUpdate.CodePostal
            };
        }
    }
}
