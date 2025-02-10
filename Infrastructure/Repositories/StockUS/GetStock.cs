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
    public class GetStock : BaseUseCase<NegosudContext>, IGetStock
    {
        public GetStock(NegosudContext context) : base(context)
        {
        }

        public Task<List<StockResponse>> ExecuteAsync(StockGetRequest input)
        {
            var stocks = _dbContext.Stock.Where(s => input.ArticleId == null || s.ArticleId == input.ArticleId).ToList();

            List<StockResponse> list = new List<StockResponse>();

            foreach (var stock in stocks) 
            {
                list.Add(new StockResponse
                {
                    Id = stock.Id,
                    ArticleId = stock.ArticleId,
                    QuantiteMax = stock.QuantiteMax,
                    QuantiteRestante = stock.QuantiteRestante,
                    DateReception = stock.DateReception,
                });
            }

            return Task.FromResult(list);
        }
    }
}
