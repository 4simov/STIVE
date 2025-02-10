using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.StockDTO
{
    public class StockUpdateRequest
    {
        public int Id { get; set; }
        public int? QuantiteMax { get; set; }
        public int? QuantiteRestante { get; set; }
    }
}
