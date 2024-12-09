using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO.Famille;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilleController : ControllerBase
    {
        private readonly NegosudContext _context;
        private readonly IGetFamille _getFamille;

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
            var familles = await _context.Famille.ToListAsync();
            
            List<FamilleResponse> familleResponse = new List<FamilleResponse>();
            foreach (var famille in familles)
            {
                familleResponse.Add(new FamilleResponse 
                {
                    Id = famille.Id,
                    Nom = famille.Nom,
                    TypeVin = famille.TypeVin,
                });
            }

            return Ok(familleResponse);
        }

        // GET: api/Famille/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Famille>> GetFamille([FromServices] IGetFamille _getFamille, int id)
        {
            var famille = await _context.Famille.FindAsync(id);

            if (famille == null)
            {
                return NotFound();
            }

            return famille;
        }

        // PUT: api/Famille/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Famille>> PostFamille(FamilleAddRequest famille)
        {
            _context.Famille.Add(new Famille { Nom = famille.Nom, TypeVin = famille.TypeVin });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamille", famille);
        }

        // DELETE: api/Famille/5
        [HttpDelete("{id}")]
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
