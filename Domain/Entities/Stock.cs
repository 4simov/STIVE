using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Il peut y avoir plusieurs stocks d'un même article
    /// </summary>
    [Table("stock")]
    public class Stock
    {
        public int Id { get; set; }
        [Column("article_fk")]
        public int ArticleId { get; set; }
        /// <summary>
        /// Quantité maximale contenue dans une palette
        /// </summary>
        [Column("quantite_max")]
        public int QuantiteMax  { get; set; }
        [Column("quantite_restante")]
        public int QuantiteRestante { get; set; }
        [Column("date_reception")]
        public DateTime DateReception { get; set; }
    }
}
