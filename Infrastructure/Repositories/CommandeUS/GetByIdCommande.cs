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
    public class GetByIdCommande : BaseUseCase<NegosudContext>, IGetByIdCommande
    {
        public GetByIdCommande(NegosudContext context) : base(context)
        {
        }

        public Task<CommandeResponse> ExecuteAsync(int input)
        {
            var commande = _dbContext.Commande
                .Include(c => c.Articles).ThenInclude(a => a.Prix)
                .FirstOrDefault(c => c.Id == input);

            if (commande == null)
            {
                throw new KeyNotFoundException($"La commande avec l'ID {input} n'a pas été trouvée.");
            }

            return Task.FromResult(CommandeQueryHelper.CommandeQuery(commande));
        }
    }
}
