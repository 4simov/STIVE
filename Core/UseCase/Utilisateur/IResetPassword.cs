using Core.DTO.UtilisateurDTO;
using STIVE.Core.UseCase;

namespace Core.UseCase.Utilisateur
{
    public interface IResetPassword : IUseCaseProcess<UtilisateurUpdateRequest, UtilisateurResponse>
    {
    }
}
