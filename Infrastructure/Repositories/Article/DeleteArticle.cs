using Core.DTO.ArticleDTO;
using Core.UseCase;
using Core.UseCase.Article;

namespace Infrastructure.Repositories
{
    public class DeleteArticle : BaseUseCase<NegosudContext>, IDeleteArticle
    {
        public DeleteArticle(NegosudContext context) : base(context)
        {
        }

        public async Task<ArticleResponse> ExecuteAsync(int input)
        {
            var article = _dbContext.Article.FirstOrDefault( a => a.Id == input);

            if (article == null)
            {
                throw new KeyNotFoundException($"Adresse avec l'ID {input} n'a pas été trouvée.");
            }

            article.IsDelete = 1;

            await _dbContext.SaveChangesAsync();

            return new ArticleResponse().GetResponse(article);  
        }
    }
}
