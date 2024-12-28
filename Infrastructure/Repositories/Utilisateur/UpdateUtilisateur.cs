using Core.DTO.Utilisateur;
using Core.UseCase;
using Core.UseCase.Utilisateur;
using STIVE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
