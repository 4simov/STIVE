
namespace Core.DTO.ArticleDTO
{
    public class ArticleUpdateRequest
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int? FamilleId { get; set; }
        public int? FournisseurId { get; set; }
        public int? SeuilMinimum { get; set; }
        public byte? ReapprovisonnementAuto { get; set; }
        public int? QuantiteAuto { get; set; }
        public string? Description { get; set; }
        // A ajouter quand la table prix_article sera prise en charge
        public float? PrixUnitaire { get; set; }
        public float? PrixCarton { get; set; }
    }
}
