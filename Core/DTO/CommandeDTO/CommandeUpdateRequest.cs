using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.CommandeDTO
{
    public class CommandeUpdateRequest
    {
        public int Id { get; set; }
        public int? Statut { get; set; }
    }
}
