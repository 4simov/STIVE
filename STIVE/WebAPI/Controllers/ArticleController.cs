using Core.DTO.ArticleDTO;
using Core.UseCase.Article;
using Core.UseCase.ArticleDTO;
using Microsoft.AspNetCore.Mvc;
using STIVE.Infrastructure;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly NegosudContext _context;

        public ArticleController(NegosudContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetArticle([FromServices] IGetArticle _getArticle)
        { 
            var articles = await _getArticle.ExecuteAsync();

            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle([FromServices] IAddArticle _addArticle, ArticleAddRequest request)
        {
            var article = await _addArticle.ExecuteAsync(request);

            return Ok(article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle([FromServices] IUpdateArticle _updateArticle, ArticleUpdateRequest request, int id)
        {
            request.Id = id;
            var article = _updateArticle.ExecuteAsync(request);

            return Ok(article);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle([FromServices] IDeleteArticle _deleteArticle, int id)
        {
            var article = await _deleteArticle.ExecuteAsync(id);

            return Ok(article);
        }

    }
}