
namespace Core.DTO.UtilisateurDTO
{
    public class UtilisateurUpdateRequest
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? AdressePays { get; set; }
        public string? AdresseRue { get; set; }
        public string? AdresseVille { get; set; }
        public string? AdresseCodePostal { get; set; }
    }
}
