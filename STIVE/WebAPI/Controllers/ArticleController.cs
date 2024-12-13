using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Article;
using Core.DTO.Famille;
using Core.UseCase.Article.Abstraction;
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
    }
}