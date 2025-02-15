using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.ArticleCommandeDTO
{
    public class ArticleCommandeAddRequest
    {
        //public int? CommandeId { get; set; }
        public int ArticleId { get; set; }
        public int PrixId { get; set; }
        public int Quantity { get; set; }
        //public int Statut { get; set; }
    }
}
