using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using STIVE.Infrastructure;
using STIVE.Domain.Entities;
using Core.DTO.AdresseDTO;

namespace Infrastructure.Repositories.AdresseNS
{
    public class AddAdresse : BaseUseCase<NegosudContext>, IAddAdresse
    {
        public AddAdresse(NegosudContext context) : base(context)
        {

        }

        public async Task<AdresseResponse> ExecuteAsync(AdresseAddRequest input)
        {
            var adresseToAdd = new Adresse { Pays = input.Pays, Rue = input.Rue, Ville = input.Ville, CodePostal = input.CodePostal };
            var add = _dbContext.Adresse.Add(adresseToAdd);
            await _dbContext.SaveChangesAsync();

            var resp = new AdresseResponse { Id = add.Entity.Id, Pays = add.Entity.Pays, Rue = add.Entity.Rue, Ville = add.Entity.Rue, CodePostal = add.Entity.CodePostal };

            return await Task.FromResult(resp);
        }
    }
}
