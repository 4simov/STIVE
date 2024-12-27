using Core.DTO.Famille;
using Core.UseCase;
using Core.UseCase.Famille.Abstraction;
using STIVE.Domain.Entities;


namespace STIVE.Infrastructure.Repositories
{
    public class AddFamille : BaseUseCase<NegosudContext>, IAddFamille
    {
        public AddFamille(NegosudContext context) : base(context)
        {
        }

        public async Task<FamilleResponse> ExecuteAsync(FamilleAddRequest input)
        {
            var familleToAdd = new Famille { Nom = input.Nom, TypeVin = input.TypeVin, Photo= input.Photo };
            var add = _dbContext.Famille.Add(familleToAdd);
            await _dbContext.SaveChangesAsync();

            var resp = new FamilleResponse { Id = add.Entity.Id, Nom = add.Entity.Nom, TypeVin = add.Entity.TypeVin, Photo = add.Entity.Photo};

            return await Task.FromResult(resp);
        }
    }
}
