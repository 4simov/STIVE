
namespace Core.DTO.FamilleDTO
{
    public class FamilleUpdateRequest
    {
        public int Id { get; set; }
        public string? Nom { get; set; }

        public byte[]? Photo { get; set; }
    }
}
