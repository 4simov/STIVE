using Core.DTO.StockDTO;
using Core.UseCase;
using Core.UseCase.StockUS;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.StockUS
{
    public class AddStock : BaseUseCase<NegosudContext>, IAddStock
    {
        public AddStock(NegosudContext context) : base(context)
        {
        }

        public async Task<StockResponse> ExecuteAsync(StockAddRequest input)
        {
            var stock = new Stock
            {
                ArticleId = input.ArticleId,
                QuantiteMax = input.QuantiteMax,
                QuantiteRestante = input.QuantiteRestante,
                DateReception = input.DateReception,
            };

            var add = _dbContext.Add(stock);
            await _dbContext.SaveChangesAsync();

            return new StockResponse
            {
                Id = add.Entity.Id,
                ArticleId = add.Entity.ArticleId,
                QuantiteMax = add.Entity.QuantiteMax,
                QuantiteRestante = add.Entity.QuantiteRestante,
                DateReception = input.DateReception,
            };
        }
    }
}
