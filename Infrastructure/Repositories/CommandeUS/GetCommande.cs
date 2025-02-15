using Core.DTO.CommandeDTO;
using Core.QueryHelpers;
using Core.UseCase;
using Core.UseCase.CommandeUS;
using Microsoft.EntityFrameworkCore;
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
            var listCommande = _dbContext.Commande
                .Include(c => c.Articles)
                .ThenInclude(a => a.Prix);

            List<CommandeResponse> commandeResponses = new List<CommandeResponse>();
            foreach (var item in listCommande) 
            { 
                commandeResponses.Add(CommandeQueryHelper.CommandeQuery(item));
            }

            return Task.FromResult(commandeResponses);
        }
    }
}
