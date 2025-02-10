using Core.DTO.StockDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.StockUS
{
    public interface IUpdateStock : IUseCaseProcess<StockUpdateRequest, StockResponse>
    {
    }
}
