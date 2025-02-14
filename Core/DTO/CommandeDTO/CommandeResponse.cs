using Core.DTO.ArticleCommandeDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.CommandeDTO
{
    public class CommandeResponse
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public DateTime Date { get; set; }
        public float PrixTotal { get; set; }
        public int Statut { get; set; }

        public ICollection<ArticleCommandeResponse> articleCommandes { get; set; }
    }
}
