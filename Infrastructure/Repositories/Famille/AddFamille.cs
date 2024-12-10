using Core.DTO.Famille;
using Core.UseCase;
using Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Infrastructure.Repositories
{
    public class AddFamille : BaseUseCase, IAddFamille
    {
        // Stocke le context de connexion de la base de donnée
        private readonly NegosudContext _context;

        public AddFamille(NegosudContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FamilleResponse> ExecuteAsync(FamilleAddRequest input)
        {
            var familleToAdd = new Famille { Nom = input.Nom, TypeVin = input.TypeVin };
            var add = _context.Famille.Add(familleToAdd);
            await _context.SaveChangesAsync();

            var resp = new FamilleResponse { Id = add.Entity.Id, Nom = add.Entity.Nom, TypeVin = add.Entity.TypeVin};

            return await Task.FromResult(resp);
        }
    }
}
