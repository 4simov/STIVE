using Core.DTO.Article;
using Core.UseCase;
using Core.UseCase.Article.Abstraction;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Article;
using STIVE.Infrastructure;
using System.Reflection.PortableExecutable;

namespace STIVE.Core.UseCase.Article
{
    public class GetArticle : BaseUseCase, IGetArticle
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;

        /// <summary>
        // On pratique ici ce que l'on appel une injection de dépendance, en gros le "context"
        // en paramètre récupère celui initialisé à l'appel de l'API et on le rattache en valeur privée et non modifiable 
        // pour chaque useCase. Tous les UseCase doivent avoir ce constructeur et la ligne
        // "private readonly NegosudContext _context;"
        /// </summary>
        /// <param name="context"></param>
        public GetArticle(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<ArticleResponse>> ExecuteAsync()
        {
            var articles = _context.Article.ToList();

            List<ArticleResponse> articleResponse = new List<ArticleResponse>();
            foreach (var article in articles)
            {
                articleResponse.Add(new ArticleResponse
                {
                    Id = article.Id,                    
                    nom = article.nom,
                    description = article.description,
                    prix_carton = article.prix_carton,
                    prix_unitaire = article.prix_unitaire,
                    quantite = article.quantite,
                    fournisseurFK = article.fournisseur_fk,
                    familleFK = article.famille_fk,
                    image = article.image,


                });
            }

            return Task.FromResult(articleResponse);
        }
    }
}
