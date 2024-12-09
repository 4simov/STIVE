using Core.DTO.Famille;
using Core.UseCase.Famille.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Famille
{
    public class AddFamille : IAddFamille
    {
        public Task<FamilleResponse> ExecuteAsync(FamilleAddRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
