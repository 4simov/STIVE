using Core.DTO.FamilleDTO;
using Core.UseCase;
using Core.UseCase.Famille.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FamilleNS
{
    public class UpdateFamille : BaseUseCase<NegosudContext>, IUpdateFamille
    {
        public UpdateFamille(NegosudContext context) : base(context)
        {
        }

        public async Task<FamilleResponse> ExecuteAsync(FamilleUpdateRequest input)
        {
            var familleToUpdate = await _dbContext.Famille.FirstOrDefaultAsync(a => a.Id == input.Id);

            if (familleToUpdate == null) 
            {
                throw new KeyNotFoundException($"La famille avec l'ID {input.Id} n'a pas été trouvée.");
            }

            familleToUpdate.Nom = input.Nom ?? familleToUpdate.Nom;

            _dbContext.Famille.Update(familleToUpdate);
            await _dbContext.SaveChangesAsync();

            var resp = new FamilleResponse { Id = familleToUpdate.Id, Nom = familleToUpdate.Nom, Photo = familleToUpdate.Photo ?? null };

            return await Task.FromResult(resp);
        }
    }
}
