using Core.DTO.FamilleDTO;
using Core.UseCase.Famille.Abstraction;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Famille.Abstraction;
using Domain.Entities;


namespace STIVE.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FamilleController : ControllerBase
    {
        private readonly NegosudContext _context;

        public FamilleController(NegosudContext context)
        {
            _context = context;

        }

        // GET: api/Famille
        [HttpGet]
        public async Task<IActionResult> GetFamille([FromServices] IGetFamille _getFamille)
        {
            var resp = await _getFamille.ExecuteAsync();
            return Ok(resp);
        }


        // GET: api/Famille/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Famille>> GetFamille([FromServices] IGetFamilleById _getFamilleById, int id)
        {

            var get = await _getFamilleById.ExecuteAsync(id);
            return Ok(get);
            //return famille;
        }

        //[Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamille([FromServices] IUpdateFamille _updateFamille, FamilleUpdateRequest input, int id)
        {
            var update = await _updateFamille.ExecuteAsync(input);
            return CreatedAtAction("PutFamille", update);
        }

        // POST: api/Famille
        [HttpPost]
        //[Authorize(Policy ="Admin")]
        public async Task<ActionResult<Famille>> PostFamille( [FromServices] IAddFamille _addFamille, FamilleAddRequest input)
        {
            var post = await _addFamille.ExecuteAsync(input);

            return CreatedAtAction("PostFamille", post);
        }

        /*// DELETE: api/Famille/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteFamille(int id)
        {
            var famille = await _context.Famille.FindAsync(id);
            if (famille == null)
            {
                return NotFound();
            }

            _context.Famille.Remove(famille);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool FamilleExists(int id)
        {
            return _context.Famille.Any(e => e.Id == id);
        }
        

    }

}
