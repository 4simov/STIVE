using Microsoft.AspNetCore.Mvc;
using Core.UseCase.PrixArticle;
using Core.DTO.PrixArticleDTO;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PrixArticleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPrixArticle([FromServices] IAddPrixArticle _addPrixArticle, [FromBody] PrixArticleAddRequest input)
        {
            var rep = await _addPrixArticle.ExecuteAsync(input);

            return CreatedAtAction("AddPrixArticle", rep);
        }
    }
}
