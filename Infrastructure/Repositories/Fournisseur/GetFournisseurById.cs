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
    public class GetFournisseurById : BaseUseCase<NegosudContext>, IGetFournisseurById
    {
        public GetFournisseurById(NegosudContext context) : base(context)
        {

        }

        public Task<FournisseurResponse> ExecuteAsync(int input)
        {
            var Fournisseur = _dbContext.Fournisseur.Include(f => f.Adresse).FirstOrDefault( f => f.Id == input);

            if(Fournisseur == null)
            {
                throw new KeyNotFoundException($"Fournisseur avec l'ID {input} n'a pas été trouvée.");
            }           

            return Task.FromResult(new FournisseurResponse
            {
                Id = Fournisseur.Id,
                Nom = Fournisseur.Nom,
                AdresseId = Fournisseur.AdresseId,
                Adresse = Fournisseur.Adresse
            });
        }
    }
}
