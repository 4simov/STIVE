using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }
        public int Role { get; set; }
        [Column("adresse_fk")]
        public int? AdresseFk { get; set; }
        public Adresse? Adresse { get; set; }
        //public string Salt { get; set; }
    }
}
