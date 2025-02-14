using Core.DTO.CommandeDTO;
using Core.QueryHelpers;
using Core.UseCase;
using Core.UseCase.CommandeUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandeUS
{
    public class UpdateCommande : BaseUseCase<NegosudContext>, IUpdateCommande
    {
        public UpdateCommande(NegosudContext context) : base(context)
        {
        }

        public Task<CommandeResponse> ExecuteAsync(CommandeUpdateRequest input)
        {
            var commande = _dbContext.Commande.FirstOrDefault( c => c.Id == input.Id);
            
            if (commande == null)
            {
                throw new KeyNotFoundException($"La commande avec l'ID {input.Id} n'a pas été trouvée.");
            }

            commande.Statut = input.Statut ?? commande.Statut;

            var commandeUpdate = _dbContext.Update(commande).Entity;
            _dbContext.SaveChanges();

            return Task.FromResult( CommandeQueryHelper.CommandeQuery(commandeUpdate));
        }
    }
}
