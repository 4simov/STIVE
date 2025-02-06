using Domain.Entities;

namespace Core.DTO.FamilleDTO
{
    public class FamilleResponse
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string? Photo { get; set; }

        public FamilleResponse GetFamilleResponse(Famille f) 
        {
            return new FamilleResponse
            {
                Id = f.Id,
                Photo = f.Photo,
                Nom = f.Nom
            };
        }
    }
}
