using Core.UseCase.PrixArticle;
using Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.PrixArticleDTO;
using Core.DTO.FamilleDTO;
using Domain.Entities;

namespace Infrastructure.Repositories.PrixArticleNS
{

    public class GetPrixArticleById : BaseUseCase<NegosudContext>, IGetPrixArticle
    {
        public GetPrixArticleById(NegosudContext context) : base(context)
        {
        }

        public Task<PrixArticleResponse> ExecuteAsync(int input)
        {
            var PrixArticle = _dbContext.PrixArticle.FirstOrDefault(f => f.Id == input);

            if (PrixArticle == null)
            {
                throw new KeyNotFoundException($"Le Prix de L'article avec l'ID {input} n'a pas été trouvée.");
            }

            return Task.FromResult(new PrixArticleResponse
            {
                Id = PrixArticle.Id,
                ArticleFk = PrixArticle.ArticleId,
                Date = PrixArticle.Date,
                Prix = PrixArticle.Prix,
                IsCarton = PrixArticle.IsCarton,
            });
        }
    }
}
