using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Domain.Entities;
using Core.DTO.AdresseDTO;
using Core.UseCase.Adresse.Abstraction;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class AddFournisseur : BaseUseCase<NegosudContext>, IAddFournisseur
    {
        private readonly IAddAdresse _addAdresse;
        public AddFournisseur(NegosudContext context, IAddAdresse addAdresse) : base(context)
        {
            _addAdresse = addAdresse;
        }

        public async Task<FournisseurResponse> ExecuteAsync(FournisseurAddRequest input)
        {
            var adresseResponse = await _addAdresse.ExecuteAsync(new AdresseAddRequest { CodePostal = input.CodePostal, Pays = input.Pays, Rue = input.Rue, Ville = input.Ville });

            var fournisseurToAdd = new Fournisseur { Nom = input.Nom, AdresseId = adresseResponse.Id };
            var add = _dbContext.Fournisseur.Add(fournisseurToAdd);
            await _dbContext.SaveChangesAsync();

            var resp = new FournisseurResponse { Id = add.Entity.Id, Nom = add.Entity.Nom, AdresseId = add.Entity.AdresseId, Adresse = add.Entity.Adresse };

            return await Task.FromResult(resp);
        }
    }
}
