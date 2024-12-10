using Core.DTO.Adresse;
using Core.UseCase;
using Core.UseCase.Adresse.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Infrastructure.Repositories.Adresse
{
    public class AddAdresse : BaseUseCase, IAddAdresse
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;
        public AddAdresse(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public Task<AdresseResponse> ExecuteAsync(AdresseAddRequest input)
        {
            throw new NotImplementedException();

        }
    }
}
