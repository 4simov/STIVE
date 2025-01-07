using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Article;

namespace Core.DTO.Article
{
    public class ArticleResponse
    {
        public int Id { get; set; }

        public string nom { get; set; }
        public float prix_carton { get; set; }
        public float prix_unitaire { get; set; }
        public int quantite { get; set; }
        public string description { get; set; }
        public byte[] image { get; set; }
        //Clé étrangère 
        public int familleFK { get; set; }
        public int fournisseurFK { get; set; }
        public string familleNom { get; set; }
    }
}
