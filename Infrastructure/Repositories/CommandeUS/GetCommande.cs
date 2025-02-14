using Core.DTO.CommandeDTO;
using Core.UseCase;
using Core.UseCase.CommandeUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandeUS
{
    public class GetCommande : BaseUseCase<NegosudContext>, IGetCommande
    {
        public GetCommande(NegosudContext context) : base(context)
        {
        }

        public Task<List<CommandeResponse>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
