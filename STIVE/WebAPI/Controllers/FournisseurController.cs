using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STIVE.Domain.Entities;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private readonly NegosudContext _context;

        public FournisseurController(NegosudContext context)
        {
            _context = context;

        }

        // GET: api/Fournisseur
        [HttpGet]
        public async Task<IActionResult> GetFournisseur([FromServices] IGetFournisseur _getFournisseur)
        {
            var resp = await _getFournisseur.ExecuteAsync();
            return Ok(resp);
        }

        // GET: api/Fournisseur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fournisseur>> GetFournisseur([FromServices] IGetFournisseur _getFournisseur, int id)
        {
            var Fournisseur = await _context.Fournisseur.FindAsync(id);

            if (Fournisseur == null)
            {
                return NotFound();
            }

            return Fournisseur;
        }

        // PUT: api/Fournisseur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFournisseur([FromServices] IUpdateFournisseur _updateFournisseur, FournisseurUpdateRequest input, int id)
        {
            input.Id = id;
            var r = await _updateFournisseur.ExecuteAsync(input);

            return CreatedAtAction("UpdateFournisseur", r);
        }

        // POST: api/Fournisseur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fournisseur>> PostFournisseur([FromServices] IAddFournisseur _addFournisseur, FournisseurAddRequest Fournisseur)
        {
            //_context.Fournisseur.Add(new Fournisseur { Nom = Fournisseur.Nom, TypeVin = Fournisseur.TypeVin });
            //await _context.SaveChangesAsync();
            var r = await _addFournisseur.ExecuteAsync(Fournisseur);

            return CreatedAtAction("GetFournisseur", r);    
        }

        // DELETE: api/Fournisseur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFournisseur([FromServices] IDeleteFournisseur _deleteFournisseur, int id)
        {
            var r = await _deleteFournisseur.ExecuteAsync(id);

            return CreatedAtAction("DeleteFournisseur", r);
        }

        private bool FournisseurExists(int id)
        {
            return _context.Fournisseur.Any(e => e.Id == id);
        }
    }
}
