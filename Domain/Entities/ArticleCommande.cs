using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("article_commande")]
    public class ArticleCommande
    {
        public int Id { get; set; }
        [Column("commande_fk")]
        public int CommandeId { get; set; }
        //public Commande? Commande { get; set; }
        [Column("article_fk")]
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
        [Column("prix_fk")]
        public int PrixId { get; set; }
        public PrixArticle? Prix { get; set; }
        public int Quantite { get; set; }
    }
}
