using Core.DTO.ArticleCommandeDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.CommandeDTO
{
    public class CommandeAddRequest
    {
        public int UtilisateurId { get; set; }
        public List<ArticleCommandeAddRequest> articles { get; set; }
    }
}
