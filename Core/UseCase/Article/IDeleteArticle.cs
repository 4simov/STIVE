using Core.DTO.ArticleDTO;
using STIVE.Core.UseCase;

namespace Core.UseCase.ArticleDTO
{
    public interface IDeleteArticle : IUseCaseProcess<int, ArticleResponse>
    {
    }
}
