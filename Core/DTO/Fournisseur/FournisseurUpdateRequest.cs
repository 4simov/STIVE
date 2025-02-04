using STIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Fournisseur
{
    public class FournisseurUpdateRequest
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Pays { get; set; }
        public string? Rue { get; set; }
        public string? Ville { get; set; }
        public string? CodePostal { get; set; }

        public int? AdresseFK { get; set; }
        public int? FournisseurFK { get; set; }
    }
}
