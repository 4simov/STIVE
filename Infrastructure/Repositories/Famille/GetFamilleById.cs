using Core.DTO.ArticleDTO;
using Core.DTO.FamilleDTO;
using Core.UseCase;
using Core.UseCase.Famille.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FamilleNS
{
    public class GetFamilleById : BaseUseCase<NegosudContext>, IGetFamilleById
    {
        public GetFamilleById(NegosudContext context) : base(context)
        {
        }

        public Task<FamilleResponse> ExecuteAsync(int input)
        {
            var famille = _dbContext.Famille.FirstOrDefault( f => f.Id == input);

            if (famille == null) 
            {
                throw new KeyNotFoundException($"La famille avec l'ID {input} n'a pas été trouvée.");
            }

            return Task.FromResult(new FamilleResponse().GetFamilleResponse(famille));
        }
    }
}
