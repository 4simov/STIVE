using Core.DTO.AdresseDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Adresse.Abstraction
{
    public interface IDeleteAdresse : IUseCaseProcess<int, AdresseResponse>
    {
    }
}
