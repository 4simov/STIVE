using Core.DTO.Fournisseur;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Fournisseur
{
    public interface IAddFournisseur : IUseCaseProcess<FournisseurAddRequest, FournisseurResponse>
    {

    }
}
