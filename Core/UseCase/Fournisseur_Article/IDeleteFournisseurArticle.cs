using Core.DTO.Fournisseur_ArticleDTO;
using STIVE.Core.UseCase;


namespace Core.UseCase.Fournisseur_Article
{
    public interface IDeleteFournisseurArticle : IUseCaseProcess<int, FournisseurArticleResponse>
    {
    }
}
