using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(string idUser, string role);
    }
}
