using Core.DTO.CommandeDTO;
using Core.QueryHelpers;
using Core.UseCase;
using Core.UseCase.CommandeUS;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandeUS
{
    public class AddCommande : BaseUseCase<NegosudContext>, IAddCommande
    {
        public AddCommande(NegosudContext context) : base(context)
        {
        }

        public Task<CommandeResponse> ExecuteAsync(CommandeAddRequest input)
        {
            var commande = new Commande
            {
                UtilisateurId = input.UtilisateurId,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Statut = (int)StatutCommandeEnum.Commande,
            };

            var commandeAdd = _dbContext.Add(commande);
            _dbContext.SaveChanges();

            foreach (var article in input.articles)
            {
                var a = new ArticleCommande
                {
                    ArticleId = article.ArticleId,
                    CommandeId = commandeAdd.Entity.Id,
                    PrixId = article.PrixId,
                    Quantite = article.Quantity,
                };

                _dbContext.ArticleCommande.Add(a);
            }
            _dbContext.SaveChanges();

            return Task.FromResult(CommandeQueryHelper.CommandeQuery(commandeAdd.Entity));
        }
    }
}
