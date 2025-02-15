using Core.DTO.CommandeDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.CommandeUS
{
    public interface IGetByIdCommande : IUseCaseProcess<int, CommandeResponse>
    {
    }
}
