using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Adresse
{
    public class AdresseAddRequest
    {
        public string Pays { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }

    }
}
