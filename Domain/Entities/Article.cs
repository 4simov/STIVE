using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string nom { get; set; }
        public float prix_carton { get; set; }
        public float prix_unitaire { get; set; }
        public int quantite { get; set; }
        public string description { get; set; }

    }
}



