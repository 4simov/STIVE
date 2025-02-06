﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Famille
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [Column("type_vin")]
        public int TypeVin { get; set; }
        [Column("Photo")]
        public byte[] Photo { get; set; }
    }
}
