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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<Famille>> GetFamille([FromServices] IGetFamille _getFamille, int id)
        {
            var famille = await _context.Famille.FindAsync(id);

            if (famille == null || famille.Photo == null)
            {
                return NotFound();
            }
            return File(famille.Photo, "image/jpeg");
            //return famille;
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamille(int id, Famille famille)
        {
            if (id != famille.Id)
            {
                return BadRequest();
            }

            _context.Entry(famille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Famille
        [HttpPost]
        [Authorize(Policy ="Admin")]
        public async Task<ActionResult<Famille>> PostFamille( [FromServices] IAddFamille _addFamille, FamilleAddRequest famille)
        {
            var r = await _addFamille.ExecuteAsync(famille);

            return CreatedAtAction("GetFamille", r);
        }

        // DELETE: api/Famille/5
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
        }

        private bool FamilleExists(int id)
        {
            return _context.Famille.Any(e => e.Id == id);
        }
        

    }

}
