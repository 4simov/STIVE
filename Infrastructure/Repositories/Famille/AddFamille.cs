using Core.DTO.FamilleDTO;
using Core.UseCase;
using Core.UseCase.Famille.Abstraction;
using Domain.Entities;


namespace Infrastructure.Repositories.FamilleNS
{
    public class AddFamille : BaseUseCase<NegosudContext>, IAddFamille
    {
        public AddFamille(NegosudContext context) : base(context)
        {
        }

        public async Task<FamilleResponse> ExecuteAsync(FamilleAddRequest input)
        {
            var familleToAdd = new Famille { Nom = input.Nom, Photo = input.Photo ?? null };
            var add = _dbContext.Famille.Add(familleToAdd);
            await _dbContext.SaveChangesAsync();

            var resp = new FamilleResponse { Id = add.Entity.Id, Nom = add.Entity.Nom, Photo = add.Entity.Photo };

            return await Task.FromResult(resp);
        }
    }
}
