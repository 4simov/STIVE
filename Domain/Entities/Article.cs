using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [Column("famille_fk")]
        public int FamilleId { get; set; }
        public Famille Famille { get; set; }
        [Column("fournisseur_fk")]
        public int FournisseurId { get; set; }
        //public Fournisseur Fournisseur { get; set; }
        [Column("seuil_minimum")]
        public int SeuilMinimum { get; set; }
        [Column("reapprovisionnement_auto")]
        public byte ReapprovisonnementAuto { get; set; }
        [Column("quantite_auto")]
        public int QuantiteAuto { get; set; }
        public string Description { get; set; }
        [Column("is_delete")]
        public byte IsDelete { get; set; }
        //public float PrixUnitaire { get; set; }
        //public float? PrixCarton { get; set; }
    }
}



