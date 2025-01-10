using Core.DTO.Fournisseur_Article;
using STIVE.Core.UseCase;


namespace Core.UseCase.Fournisseur_Article
{
    public interface IUpdateFournisseurArticle : IUseCaseProcess<FournisseurArticleUpdateRequest, FournisseurArticleResponse>
    {
    }
}
