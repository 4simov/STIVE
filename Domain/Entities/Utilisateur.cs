using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int AdresseFk { get; set; }
        //public string Salt { get; set; }
    }
}
