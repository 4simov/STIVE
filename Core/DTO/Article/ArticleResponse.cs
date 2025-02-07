using Domain.Entities;

namespace Core.DTO.ArticleDTO
{
    public class ArticleResponse : IResponseHelper<Article, ArticleResponse>
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public float PrixCarton { get; set; }
        public float PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public int QuantiteAuto { get; set; }
        public string Description { get; set; }
        public byte ReapprovisonnementAuto { get; set; }
        public byte[] Image { get; set; }
        //Clé étrangère 
        public int FamilleId { get; set; }
        public int FournisseurId { get; set; }
        public string FournisseurNom {  get; set; }
        public string FamilleNom { get; set; }

        public ArticleResponse GetResponse(Article source)
        {
            // Création de la réponse
            var resp = new ArticleResponse
            {
                Id = source.Id,
                Nom = source.Nom,
                //à implémenter quand on aura la table article_prix
                PrixCarton = 0,
                //à implémenter quand on aura la table article_prix
                PrixUnitaire = 0,
                //à implémenter quand on aura la table Stock
                Quantite = 0,
                Description = source.Description,
                FournisseurId = source.FournisseurId,
                FamilleId = source.FamilleId,
                //à implémenter
                Image = null
            };

            return resp;
        }
    }
}
