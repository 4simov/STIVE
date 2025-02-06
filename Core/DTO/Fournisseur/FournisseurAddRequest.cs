using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.FournisseurDTO
{
    public class FournisseurAddRequest
    {
        public string Nom { get; set; }
        public string Pays { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
    }
}
