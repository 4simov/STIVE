using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Article;
using Core.DTO.Famille;
using Core.UseCase.Article.Abstraction;
using Core.UseCase.Famille.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Article;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly NegosudContext _context;
        private readonly IGetFamille _getArticle;

        public ArticleController(NegosudContext context)
        {
            _context = context;

        }

        // GET: Article
        [HttpGet]
        public async Task<IActionResult> GetArticle([FromServices] IGetArticle _getArticle)
        {
            var resp = await _getArticle.ExecuteAsync();
            return Ok(resp);
            var articles = await _context.Article.ToListAsync();

            List<ArticleResponse> ArticleResponse = new List<ArticleResponse>();
            foreach (var article in articles)
            {

                ArticleResponse.Add(new ArticleResponse
                {

                    Id = article.Id,
                    quantite = article.quantite,
                    prix_unitaire = article.prix_unitaire,
                    prix_carton = article.prix_carton,
                    nom = article.nom,
                    description = article.description,



                });
            }
            return Ok(ArticleResponse);

        }

        // POST: Article
    //    [HttpPost]
    //    public async Task<ActionResult<Article>> PostArticle(
    //[FromServices] IAddArticle _addArticle,
    //ArticleAddRequest article)
    //    {
    //        // Si aucune famille n'est spécifiée, continuer (famille_fk peut être NULL)
    //        if (article.quantite != null)
    //        {
    //            var familleExists = await _dbContext.Familles.AnyAsync(f => f.Id == article.familleFK);
    //            if (!familleExists)
    //            {
    //                return BadRequest(new { message = "La famille spécifiée n'existe pas." });
    //            }
    //        }

    //        // Ajouter l'article
    //        var r = await _addArticle.ExecuteAsync(article);

    //        return CreatedAtAction("GetArticle", new { id = r.Id }, r);
    //    }



    }
}