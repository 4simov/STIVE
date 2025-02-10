using Core.DTO.StockDTO;
using Core.UseCase;
using Core.UseCase.StockUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.StockUS
{
    public class UpdateStock : BaseUseCase<NegosudContext>, IUpdateStock
    {
        public UpdateStock(NegosudContext context) : base(context)
        {
        }

        public Task<StockResponse> ExecuteAsync(StockUpdateRequest input)
        {
            var stock = _dbContext.Stock.FirstOrDefault( s => s.Id == input.Id );

            if (stock == null) 
            {
                throw new KeyNotFoundException($"Stock avec l'ID {input.Id} n'a pas été trouvée.");
            }

            stock.QuantiteMax = input.QuantiteMax ?? stock.QuantiteMax;
            stock.QuantiteRestante = input.QuantiteRestante ?? stock.QuantiteRestante;

            var change = _dbContext.Stock.Update( stock );
            _dbContext.SaveChanges();

            return Task.FromResult( new StockResponse
            {
                Id = change.Entity.Id,
                ArticleId = change.Entity.ArticleId,
                QuantiteMax = change.Entity.QuantiteMax,
                QuantiteRestante = change.Entity.QuantiteRestante,
                DateReception = change.Entity.DateReception,
            } );
        }
    }
}
