namespace Core.DTO.FamilleDTO
{
    public class FamilleResponse
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int TypeVin { get; set; }

        public byte[] Photo { get; set; }

    }
}
