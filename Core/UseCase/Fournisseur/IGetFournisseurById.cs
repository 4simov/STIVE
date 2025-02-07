using Core.DTO.FournisseurDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Fournisseur
{
    public interface IGetFournisseurById : IUseCaseProcess<int, FournisseurResponse>
    {
    }
}
