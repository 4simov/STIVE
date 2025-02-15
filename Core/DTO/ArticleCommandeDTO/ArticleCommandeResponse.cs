﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.ArticleCommandeDTO
{
    public class ArticleCommandeResponse
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int PrixId { get; set; }
        public PrixArticle PrixArticle { get; set; }
        public float Prix {  get; set; }
        public float Quantity { get; set; }
        public float PrixTotal { get; set; }
    }
}
