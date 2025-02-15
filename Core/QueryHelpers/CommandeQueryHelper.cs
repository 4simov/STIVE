using Core.DTO.ArticleCommandeDTO;
using Core.DTO.ArticleDTO;
using Core.DTO.CommandeDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryHelpers
{
    /// <summary>
    /// Sert à convertir les entités de la base en réponse pour le client
    /// </summary>
    public class CommandeQueryHelper
    {

        public static ArticleCommandeResponse ArticleCommandeQuery( ArticleCommande articleCommande)
        {
            ArticleCommandeResponse articleCommandeResponse = new ArticleCommandeResponse
            {
                Id = articleCommande.Id,
                CommandeId = articleCommande.CommandeId,
                ArticleId = articleCommande.ArticleId,
                //Article = articleCommande.Article,
                PrixId = articleCommande.PrixId,
                Prix = articleCommande.Prix.Prix,
                Quantity = articleCommande.Quantite,
                PrixTotal = articleCommande.Prix.Prix * articleCommande.Quantite
            };

            return articleCommandeResponse;
        }

        public static CommandeResponse CommandeQuery( Commande commande)
        {
            List<ArticleCommandeResponse> articles = new List<ArticleCommandeResponse>();

            foreach (var article in commande.Articles)
            {
                articles.Add(ArticleCommandeQuery(article));
            }

            CommandeResponse commandeResponse = new CommandeResponse
            {
                Id = commande.Id,
                Date = DateTime.Now,
                PrixTotal = articles.Sum(a => a.PrixTotal),
                UtilisateurId = commande.UtilisateurId,
                Statut = commande.Statut,
                articleCommandes = articles,
            };

            return commandeResponse;
        }
    }
}
