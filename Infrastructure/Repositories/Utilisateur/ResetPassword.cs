using Core.DTO.UtilisateurDTO;
using Core.UseCase;
using Core.UseCase.Utilisateur;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.UtilisateurNS
{
    public class ResetPassword : BaseUseCase<NegosudContext>, IResetPassword
    {
        public ResetPassword(NegosudContext context) : base(context)
        {
        }

        public Task<UtilisateurResponse> ExecuteAsync(UtilisateurUpdateRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
