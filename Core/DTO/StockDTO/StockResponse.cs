using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.StockDTO
{
    public class StockResponse
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int QuantiteMax { get; set; }
        public int QuantiteRestante { get; set; }
        public DateTime DateReception { get; set; }
    }
}
