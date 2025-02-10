using Core.DTO.StockDTO;
using Core.UseCase.StockUS;
using Microsoft.AspNetCore.Mvc;

namespace STIVE.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetStock([FromServices] IGetStock _getStock, [FromQuery] StockGetRequest input)
        {
            var resp = await _getStock.ExecuteAsync(input);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock([FromServices] IAddStock _addStock, StockAddRequest input)
        {
            var resp = await _addStock.ExecuteAsync(input);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> AddStock([FromServices] IUpdateStock updateStock, StockUpdateRequest input)
        {
            var resp = await updateStock.ExecuteAsync(input);
            return Ok(resp);
        }
    }
}
