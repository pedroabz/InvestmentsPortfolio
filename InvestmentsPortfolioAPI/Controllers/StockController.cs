using InvestmentsPortfolioAPI.Application.DTO;
using InvestmentsPortfolioAPI.Application.HttpMessages;
using InvestmentsPortfolioAPI.Application.Mappers;
using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsPortfolioAPI.Controllers
{

    public class StockController : BaseController
    {
        public readonly IRepository<Stock> _stockRepository;
        public StockController(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StockDTO newStock)
        {
            if (_stockRepository.FirstOrDefault(x => x.Code == newStock.Code) != null)
                throw new BadRequestException(StockMessages.StockAlreadyExists);
            _stockRepository.Create(newStock.ToModel());
            return Ok();
        }

        [Route ("{code}")]
        [HttpGet]
        public IActionResult Get (string code)
        {
            var stock = _stockRepository.FirstOrDefault(x => x.Code == code);
            if (stock == null)
                return NotFound(StockMessages.NoStockWithThisCode);
            return Ok(stock.ToDto());
        }

        [Route("{code}")]
        [HttpDelete]
        public IActionResult Delete(string code)
        {
            var stockToDelete = _stockRepository.FirstOrDefault(x => x.Code == code);
            if (stockToDelete != null)
            {            
                _stockRepository.Delete(stockToDelete);
                return Ok();
            }

            return NotFound(StockMessages.NoStockWithThisCode);
        }
    }
}
