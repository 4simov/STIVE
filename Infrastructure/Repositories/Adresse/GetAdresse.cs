using Core.DTO.Adresse;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.Adresse
{
    public class GetAdresse : BaseUseCase, IGetAdresse
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;

        /// <summary>
        // On pratique ici ce que l'on appel une injection de dépendance, en gros le "context"
        // en paramètre récupère celui initialisé à l'appel de l'API et on le rattache en valeur privée et non modifiable 
        // pour chaque useCase. Tous les UseCase doivent avoir ce constructeur et la ligne
        // "private readonly NegosudContext _context;"
        /// </summary>
        /// <param name="context"></param>
        public GetAdresse(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<AdresseResponse>> ExecuteAsync()
        {
            var Adresses = _context.Adresse.ToList();

            List<AdresseResponse> AdresseResponse = new List<AdresseResponse>();
            foreach (var Adresse in Adresses)
            {
                AdresseResponse.Add(new AdresseResponse
                {
                    Id = Adresse.Id,
                    Pays = Adresse.Pays,
                    Rue = Adresse.Rue,
                    Ville = Adresse.Ville,
                    CodePostal = Adresse.CodePostal,

                });
            }

            return Task.FromResult(AdresseResponse);
        }
    }
}
