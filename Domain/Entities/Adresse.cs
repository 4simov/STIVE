using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Domain.Entities
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Pays { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        [Column("code_postal")]
        public string CodePostal { get; set; }
    }
}
