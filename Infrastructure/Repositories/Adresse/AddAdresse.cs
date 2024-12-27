using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using STIVE.Domain.Entities;
using Core.DTO.Adresse;
using STIVE.Core.UseCase;

namespace STIVE.Infrastructure.Repositories
{
    public class AddAdresse : BaseUseCase, IAddAdresse
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;

        public AddAdresse(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AdresseResponse> ExecuteAsync(AdresseAddRequest input)
        {
            var adresseToAdd = new Adresse { Pays = input.Pays, Rue = input.Rue, Ville = input.Ville, CodePostal = input.CodePostal };
            var add = _context.Adresse.Add(adresseToAdd);
            await _context.SaveChangesAsync();

            var resp = new AdresseResponse { Id = add.Entity.Id, Pays = add.Entity.Pays, Rue = add.Entity.Rue, Ville = add.Entity.Rue, CodePostal = add.Entity.CodePostal };

            return await Task.FromResult(resp);
        }
    }
}
