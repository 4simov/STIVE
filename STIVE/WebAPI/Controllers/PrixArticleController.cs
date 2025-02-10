using Microsoft.AspNetCore.Mvc;
using Core.UseCase.PrixArticle;
using Core.DTO.PrixArticleDTO;
using Core.UseCase.Famille.Abstraction;
using Domain.Entities;

namespace STIVE.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PrixArticleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPrixArticle([FromServices] IAddPrixArticle _addPrixArticle, [FromBody] PrixArticleAddRequest input)
        {
            var rep = await _addPrixArticle.ExecuteAsync(input);

            return CreatedAtAction("AddPrixArticle", rep);
        }

        // GET: api/PrixArticle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Famille>> GetPrixArticleById([FromServices] IGetPrixArticle _getPrixArticleById, int id)
        {

            var get = await _getPrixArticleById.ExecuteAsync(id);
            return Ok(get);
            //return PrixArticle;
        }
    }
}
