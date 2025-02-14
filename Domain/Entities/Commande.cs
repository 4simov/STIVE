using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("commande")]
    public class Commande
    {
        [Key]
        public int Id { get; set; }
        [Column("client_fk")]
        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public string Date { get; set; }
        public int Statut { get; set; }

        public ICollection<ArticleCommande> Articles { get; set; }
    }
}
