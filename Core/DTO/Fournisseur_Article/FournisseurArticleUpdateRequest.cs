using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Fournisseur_Article
{
    public class FournisseurArticleUpdateRequest
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int? ArticleFK { get; set; }
        public int? FournisseurFK { get; set; }
    }
}
