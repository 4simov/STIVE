using STIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Fournisseur
{
    public class FournisseurResponse
    {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }
    }
}
