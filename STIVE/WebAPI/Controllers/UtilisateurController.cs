using Core.DTO.UtilisateurDTO;
using Core.Services.Token;
using Core.UseCase.Utilisateur;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;



namespace STIVE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly NegosudContext _context;

        public UtilisateurController(NegosudContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] ILogin _login, [FromServices] ITokenGenerator _token, UtilisateurLoginRequest request)
        {
            var resp = await _login.ExecuteAsync(request);
            return Ok(resp);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authentification([FromServices] IAddUtilisateur _auth, UtilisateurAddRequest request)
        {
            var resp = await _auth.ExecuteAsync(request);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Famille>> GetFamille([FromServices] IAddUtilisateur _getFamille, int id)
        {
            var famille = await _context.Famille.FindAsync(id);

            if (famille == null || famille.Photo == null)
            {
                return NotFound();
            }
            return File(famille.Photo, "image/jpeg");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur([FromServices] IUpdateUtilisateur _updateUtilisateur, int id, UtilisateurUpdateRequest request)
        {
            //Récupération de l'id de l'utilisateur à partir de son token
            request.Id = HttpContext.Items["UserId"]?.ToString();
            if(request.Id == null)
            {
                return Unauthorized();
            }
            var resp = _updateUtilisateur.ExecuteAsync(request);
            return NoContent();
        }

        /// <summary>
        /// Doit effacer l'utilisateur 
        /// Seul les Admins ou le propre possesseur du compte peuvent effacer le compte
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("reset-password")]
        [Authorize(Policy ="Client")]
        public async Task<IActionResult> Authentification([FromServices] IResetPassword _reset, UtilisateurUpdateRequest request)
        {
            var resp = await _reset.ExecuteAsync(request);
            return Ok(resp);
        }
    }

}
