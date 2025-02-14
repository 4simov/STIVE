using Core.DTO.CommandeDTO;
using Core.UseCase.CommandeUS;
using Microsoft.AspNetCore.Mvc;
using STIVE.Core.UseCase.Famille.Abstraction;

namespace STIVE.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        // GET: api/Famille
        [HttpGet]
        public async Task<IActionResult> GetCommande([FromServices] IGetCommande _getCommande)
        {
            var resp = await _getCommande.ExecuteAsync();
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommande([FromServices] IAddCommande _addCommande, CommandeAddRequest input)
        {
            var resp = await _addCommande.ExecuteAsync(input);
            return Ok(resp);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCommande([FromServices] IUpdateCommande _updateCommande, CommandeUpdateRequest input, int id)
        {
            input.Id = id;
            var resp = await _updateCommande.ExecuteAsync(input);
            return Ok(resp);
        }
    }
}
