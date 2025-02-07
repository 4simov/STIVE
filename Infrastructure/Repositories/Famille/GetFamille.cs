using Core.DTO.FamilleDTO;
using Core.UseCase;
using STIVE.Core.UseCase.Famille.Abstraction;

namespace Infrastructure.Repositories.FamilleNS
{
    public class GetFamille : BaseUseCase<NegosudContext>, IGetFamille
    {
        public GetFamille(NegosudContext context) : base(context)
        {
        }

        public Task<List<FamilleResponse>> ExecuteAsync()
        {
            var familles = _dbContext.Famille.ToList();

            List<FamilleResponse> familleResponse = new List<FamilleResponse>();
            foreach (var famille in familles)
            {
                familleResponse.Add(new FamilleResponse
                {
                    Id = famille.Id,
                    Nom = famille.Nom,
                    Photo = famille.Photo,
                });
            }

            return Task.FromResult(familleResponse);
        }
    }
}
