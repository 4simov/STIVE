using Core.DTO.Famille;
using Core.UseCase;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Infrastructure;

namespace STIVE.Core.UseCase.Famille
{
    public class UpdateFamille : BaseUseCase, IGetFamille
    {
        /// <summary>
        // On pratique ici ce que l'on appel une injection de dépendance, en gros le "context"
        // en paramètre récupère celui initialisé à l'appel de l'API et on le rattache en valeur privée et non modifiable 
        // pour chaque useCase. Tous les UseCase doivent avoir ce constructeur et la ligne
        // "private readonly NegosudContext _context;"
        /// </summary>
        /// <param name="context"></param>
        private readonly NegosudContext _context;

        public UpdateFamille(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<FamilleResponse>> ExecuteAsync()
        {
            var familles = _context.Famille.ToList();

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

            return Task.FromResult(familleResponse);
        }
    }
}
