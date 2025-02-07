using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fournisseur_Article
    {
        public int Id { get; set; }
        public int IdFournisseur {  get; set; }
        public int IdArticle { get; set; }
        public int NomFournisseur { get; set; }
        public int NomArticle { get; set; }
    }
}
