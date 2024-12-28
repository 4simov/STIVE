using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Utilisateur
{
    public class UtilisateurUpdateRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Mdp { get; set; }
        public int Role { get; set; } = 0;//0 => pas de role
        public string? AdressePays { get; set; }
        public string? AdresseRue { get; set; }
        public string? AdresseVille { get; set; }
        public string? AdresseCodePostal { get; set; }
    }
}
