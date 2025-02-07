using Core.DTO.ArticleDTO;
using Core.UseCase;
using Core.UseCase.Article;

namespace Infrastructure.Repositories
{
    public class GetArticle : BaseUseCase<NegosudContext>, IGetArticle
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
                articleResponse.Add(new ArticleResponse().GetResponse(article));
            }
            
            return Task.FromResult(articleResponse);
        }
    }
}
