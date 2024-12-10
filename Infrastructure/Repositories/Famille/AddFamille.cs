using Core.DTO.Famille;
using Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Famille
{
    public class AddFamille : BaseUseCase, IAddFamille
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;

        public AddFamille(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public Task<FamilleResponse> ExecuteAsync(FamilleAddRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
