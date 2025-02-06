using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Famille
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Photo { get; set; }
    }
}
