
namespace Core.DTO.UtilisateurDTO
{
    public class UtilisateurAddRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }
        public string? AdressePays { get; set; }
        public string? AdresseRue { get; set; }
        public string? AdresseVille { get; set; }
        public string? AdresseCodePostal { get; set; }
    }
}
