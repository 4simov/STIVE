using STIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [Column("adresse_fk")]
        public int AdresseId { get; set; }
        public Adresse ?Adresse { get; set; }
    }
}
