using Core.DTO.ArticleDTO;
using Core.UseCase;
using Core.UseCase.Article;
using STIVE.Domain.Entities;

namespace STIVE.Infrastructure.Repositories;

public class AddArticle : BaseUseCase<NegosudContext>, IAddArticle
{
    // Stocke le contexte de connexion à la base de données
    private readonly NegosudContext _context;

    public AddArticle(NegosudContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ArticleResponse> ExecuteAsync(ArticleAddRequest input)
    {
        // Création de l'article à ajouter
        var articleToAdd = new Article
        {
            Nom = input.Nom,
            Description = input.Description,
            FournisseurId = input.FournisseurId,
            FamilleId = input.FamilleId,
            ReapprovisonnementAuto = input.ReapprovisionnementAuto,
            QuantiteAuto = input.QuantiteAuto,
            SeuilMinimum = input.SeuilMinimum,
            IsDelete = 0
        };

        // Ajout de l'article dans le contexte
        var add = _context.Article.Add(articleToAdd);
        await _context.SaveChangesAsync();

        // Création de la réponse
        var resp = new ArticleResponse
        {
            Id = add.Entity.Id,
            Nom = add.Entity.Nom,
            //à implémenter quand on aura la table article_prix
            PrixCarton = 0,
            //à implémenter quand on aura la table article_prix
            PrixUnitaire = 0,
            //à implémenter quand on aura la table Stock
            Quantite = 0,
            Description = add.Entity.Description,
            FournisseurId = input.FournisseurId,
            FamilleId = input.FamilleId,
            //à implémenter
            Image = null
        };
        
        return await Task.FromResult(resp);
    }
}


