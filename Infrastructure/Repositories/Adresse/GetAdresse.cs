using Core.DTO.Adresse;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.AdresseNS
{
    public class GetAdresse : BaseUseCase<NegosudContext>, IGetAdresse
    {
        public GetAdresse(NegosudContext context) : base(context)
        {
        }

        public Task<List<AdresseResponse>> ExecuteAsync()
        {
            var Adresses = _dbContext.Adresse.ToList();

            List<AdresseResponse> AdresseResponse = new List<AdresseResponse>();
            foreach (var Adresse in Adresses)
            {
                AdresseResponse.Add(new AdresseResponse
                {
                    Id = Adresse.Id,
                    Pays = Adresse.Pays,
                    Rue = Adresse.Rue,
                    Ville = Adresse.Ville,
                    CodePostal = Adresse.CodePostal,

                });
            }

            return Task.FromResult(AdresseResponse);
        }
    }
}
