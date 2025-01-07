using Core.DTO.Fournisseur;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UseCase.Fournisseur;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class GetFournisseur : BaseUseCase<NegosudContext>, IGetFournisseur
    {
        public GetFournisseur(NegosudContext context) : base(context)
        {
        }

        public Task<List<FournisseurResponse>> ExecuteAsync()
        {
            var Fournisseurs = _dbContext.Fournisseur.ToList();

            List<FournisseurResponse> FournisseurResponse = new List<FournisseurResponse>();
            foreach (var Fournisseur in Fournisseurs)
            {
                FournisseurResponse.Add(new FournisseurResponse
                {
                    Id = Fournisseur.Id,
                    Nom = Fournisseur.Nom,
                    AdresseFK = Fournisseur.AdresseId
                });
            }

            return Task.FromResult(FournisseurResponse);
        }
    }
}
