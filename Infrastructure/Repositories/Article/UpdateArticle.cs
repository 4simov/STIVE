using Core.DTO.ArticleDTO;
using Core.UseCase;
using Core.UseCase.Article;
using Microsoft.EntityFrameworkCore;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.Article
{
    public class UpdateArticle : BaseUseCase<NegosudContext>, IUpdateArticle
    {
        public UpdateArticle(NegosudContext context) : base(context)
        {
        }

        public async Task<ArticleResponse> ExecuteAsync(ArticleUpdateRequest input)
        {
            // Vérifie si l'adresse existe
            var articleToUpdate = await _dbContext.Article.FirstOrDefaultAsync(a => a.Id == input.Id);

            if (articleToUpdate == null)
            {
                throw new KeyNotFoundException($"Adresse avec l'ID {input.Id} n'a pas été trouvée.");
            }

            // Met à jour les champs de l'adresse
            articleToUpdate.FournisseurId = input.FournisseurId ?? articleToUpdate.FournisseurId;
            articleToUpdate.Description = input.Description ?? articleToUpdate.Description;
            articleToUpdate.FamilleId = input.FamilleId ?? articleToUpdate.FamilleId;
            articleToUpdate.SeuilMinimum = input.SeuilMinimum ?? articleToUpdate.SeuilMinimum;
            articleToUpdate.Nom = input.Nom ?? articleToUpdate.Nom;
            articleToUpdate.QuantiteAuto = input.QuantiteAuto ?? articleToUpdate.QuantiteAuto;
            articleToUpdate.ReapprovisonnementAuto = input.ReapprovisonnementAuto ?? articleToUpdate.ReapprovisonnementAuto;

            // Sauvegarde les changements
            _dbContext.Article.Update(articleToUpdate);
            await _dbContext.SaveChangesAsync();

            return new ArticleResponse().GetResponse(articleToUpdate);
        }
    }
}
