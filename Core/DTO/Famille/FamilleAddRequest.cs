using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DTO.Famille
{
    public class FamilleAddRequest
    {
        public string Nom { get; set; }
        public int TypeVin { get; set; }
    }
}
