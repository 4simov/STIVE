using Core.DTO.UtilisateurDTO;
using Core.UseCase;
using Core.UseCase.Utilisateur;

namespace Infrastructure.Repositories.UtilisateurNS
{
    internal class UpdateUtilisateur : BaseUseCase<NegosudContext>, IUpdateUtilisateur
    {
        public UpdateUtilisateur(NegosudContext context) : base(context)
        {
        }

        public Task<UtilisateurResponse> ExecuteAsync(UtilisateurUpdateRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
