using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using STIVE.Domain.Entities;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UseCase.Fournisseur;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class AddFournisseur : BaseUseCase<NegosudContext>, IAddFournisseur
    {
        public AddFournisseur(NegosudContext context) : base(context)
        {

        }
        public async Task<FournisseurResponse> ExecuteAsync(FournisseurAddRequest input)
        {
            var fournisseurToAdd = new Fournisseur { Nom = input.Nom, AdresseFk = input.AdresseFK };
            var add = _dbContext.Fournisseur.Add(fournisseurToAdd);
            await _dbContext.SaveChangesAsync();

            var resp = new FournisseurResponse { Id = add.Entity.Id, Nom = add.Entity.Nom, AdresseFK = add.Entity.AdresseFk };

            return await Task.FromResult(resp);
        }
    }
}
