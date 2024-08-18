using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public ActionResult<List<Stock>> GetStocks()
        {
            var stocks = _stockService.GetStocks();
            return Ok(stocks);
        }

        [HttpGet("{ID}")]
        public ActionResult<Stock> GetStock(int id)
        {
            var stock = _stockService.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public ActionResult AddStock([FromBody] Stock stock)
        {
            if (stock == null)
            {
                return BadRequest();
            }
            _stockService.StockAdd(stock);
            return CreatedAtAction(nameof(GetStock), new { id = stock.ID }, stock);
        }

        [HttpPut("{ID}")]
        public ActionResult UpdateStock(int id, [FromBody] Stock stock)
        {
            if (stock == null || stock.ID != id)
            {
                return BadRequest();
            }

            var existingStock = _stockService.GetById(id);
            if (existingStock == null)
            {
                return NotFound();
            }

            _stockService.StockUpdate(stock);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult DeleteStock(int id)
        {
            var stock = _stockService.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }

            _stockService.StockRemove(stock);
            return NoContent();
        }
    }
}
