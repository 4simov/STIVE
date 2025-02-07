using Core.DTO.PrixArticleDTO;
using Core.UseCase;
using Core.UseCase.PrixArticle;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PrixArticleNS
{
    public class AddPrixArticle : BaseUseCase<NegosudContext>, IAddPrixArticle
    {
        public AddPrixArticle(NegosudContext context) : base(context)
        {
        }

        public Task<PrixArticleResponse> ExecuteAsync(PrixArticleAddRequest input)
        {
            var prixArticleToAdd = new PrixArticle
            {
                ArticleId = input.ArticleFk,
                Prix = input.Prix,
                Date = DateTime.Now,
                IsCarton = input.IsCarton,
            };

            var response = _dbContext.Add(prixArticleToAdd);
            _dbContext.SaveChanges();

            return Task.FromResult(new PrixArticleResponse
            {
                Id = response.Entity.Id,
                ArticleFk = response.Entity.ArticleId,
                Prix = response.Entity.Prix,
                Date = response.Entity.Date,
                IsCarton = response.Entity.IsCarton
            });
        }
    }
}
