using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("prix_article")]
    public class PrixArticle
    {
        public int Id { get; set; }
        [Column("article_fk")]
        public int ArticleId {  get; set; }
        public Article Article { get; set; }
        public DateTime Date { get; set; }
        public float Prix {  get; set; }
        [Column("is_carton")]
        public bool IsCarton { get; set; }
    }
}
