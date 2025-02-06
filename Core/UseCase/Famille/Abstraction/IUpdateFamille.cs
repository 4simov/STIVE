using Core.DTO.FamilleDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Famille.Abstraction
{
    public interface IUpdateFamille : IUseCaseProcess<FamilleUpdateRequest, FamilleResponse>
    {
    }
}
