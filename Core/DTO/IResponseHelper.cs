using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public interface IResponseHelper<ClasseSource, ClasseToReturn>
    {
        public ClasseToReturn GetResponse(ClasseSource source);
    }
}
