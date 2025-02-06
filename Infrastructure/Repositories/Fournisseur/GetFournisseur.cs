using Core.DTO.FournisseurDTO;
using Core.UseCase.Fournisseur;
using Core.UseCase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FournisseurNS
{
    public class GetFournisseur : BaseUseCase<NegosudContext>, IGetFournisseur
    {
        public GetFournisseur(NegosudContext context) : base(context)
        {
        }

        public Task<List<FournisseurResponse>> ExecuteAsync()
        {
            var Fournisseurs = _dbContext.Fournisseur.Include( f => f.Adresse).ToList();

            List<FournisseurResponse> FournisseurResponse = new List<FournisseurResponse>();
            foreach (var Fournisseur in Fournisseurs)
            {
                FournisseurResponse.Add(new FournisseurResponse
                {
                    Id = Fournisseur.Id,
                    Nom = Fournisseur.Nom,
                    AdresseId = Fournisseur.AdresseId,
                    Adresse = Fournisseur.Adresse
                });
            }

            return Task.FromResult(FournisseurResponse);
        }
    }
}
