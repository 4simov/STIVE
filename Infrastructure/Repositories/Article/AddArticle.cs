using Core.DTO.Article;
using Core.UseCase;
using Core.UseCase.Article.Abstraction;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace STIVE.Infrastructure.Repositories;
public class AddArticle : BaseUseCase, IAddArticle
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
            nom = input.nom,
            prix_carton = input.prix_carton,
            prix_unitaire = input.prix_unitaire,
            quantite = input.quantite,
            description = input.description,
            fournisseur_fk = input.fournisseurFK,
            //famille_fk = input.familleFK,
            

        };

        // Ajout de l'article dans le contexte
        var add = _context.Article.Add(articleToAdd);
        await _context.SaveChangesAsync();

        // Création de la réponse
        var resp = new ArticleResponse
        {
            Id = add.Entity.Id,
            nom = add.Entity.nom,
            prix_carton = add.Entity.prix_carton,
            prix_unitaire = add.Entity.prix_unitaire,
            quantite = add.Entity.quantite,
            description = add.Entity.description,
            fournisseurFK = input.fournisseurFK,
            familleFK = input.familleFK,
            image = input.image,
        };

        return await Task.FromResult(resp);
    }
}


