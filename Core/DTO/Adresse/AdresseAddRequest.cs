﻿namespace Core.DTO.Adresse
{
    public class AdresseAddRequest
    {
        public int? Id { get; set; }
        public string Pays { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
    }
}
