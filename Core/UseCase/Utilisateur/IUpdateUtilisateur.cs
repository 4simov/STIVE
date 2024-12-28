using Core.DTO.Utilisateur;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Utilisateur
{
    public interface IUpdateUtilisateur : IUseCaseProcess<UtilisateurUpdateRequest, UtilisateurResponse>
    {
    }
}
