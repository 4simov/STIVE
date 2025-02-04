using Core.DTO.ArticleDTO;
using STIVE.Core.UseCase;

namespace Core.UseCase.Article
{
    public interface IDeleteArticle : IUseCaseProcess<int, ArticleResponse>
    {
    }
}
