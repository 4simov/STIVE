using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.PrixArticleDTO
{
    public class PrixArticleAddRequest
    {
        public int ArticleFk { get; set; }
        public float Prix { get; set; }
        public bool IsCarton { get; set; }
    }
}
