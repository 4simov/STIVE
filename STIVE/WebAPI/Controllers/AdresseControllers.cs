using Core.DTO.Adresse;
using Core.UseCase.Adresse.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;

namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly NegosudContext _context;
        private readonly IGetAdresse _getAdresse;

        public AdresseController(NegosudContext context)
        {
            _context = context;

        }

        // GET: api/Adresse
        [HttpGet]
        public async Task<IActionResult> GetAdresse([FromServices] IGetAdresse _getAdresse)
        {
            var resp = await _getAdresse.ExecuteAsync();
            return Ok(resp);
        }

        // GET: api/Adresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetAdresse([FromServices] IGetAdresse _getAdresse, int id)
        {
            var Adresse = await _context.Adresse.FindAsync(id);

            if (Adresse == null)
            {
                return NotFound();
            }

            return Adresse;
        }

        // PUT: api/Adresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse([FromServices] IUpdateAdresse _updateAdresse, AdresseAddRequest input, int id)
        {
            input.Id = id;
            var r = await _updateAdresse.ExecuteAsync(input);

            return CreatedAtAction("UpdateAdresse", r);
        }

        // POST: api/Adresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adresse>> PostAdresse([FromServices] IAddAdresse _addAdresse, AdresseAddRequest Adresse)
        {
            //_context.Adresse.Add(new Adresse { Nom = Adresse.Nom, TypeVin = Adresse.TypeVin });
            //await _context.SaveChangesAsync();
            var r = await _addAdresse.ExecuteAsync(Adresse);

            return CreatedAtAction("GetAdresse", r);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse([FromServices] IDeleteAdresse _deleteAdresse, int id )
        {
            var r = await _deleteAdresse.ExecuteAsync(id);

            return CreatedAtAction("DeleteAdresse", r);
        }

        private bool AdresseExists(int id)
        {
            return _context.Adresse.Any(e => e.Id == id);
        }
    }
}
