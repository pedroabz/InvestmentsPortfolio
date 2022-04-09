using InvestmentsPortfolio.Application.ApplicationServices.Interfaces;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using InvestmentsPortfolioAPI.HttpMessages;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsPortfolioAPI.Controllers
{

    public class StockController : BaseController
    {
        public readonly IStockApplicationService _service;
        public StockController(IStockApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<StockResponse> Post([FromBody] StockRequest newStock)
        {
            return _service.Create(newStock);
        }

        [Route ("{code}")]
        [HttpGet]
        public IActionResult Get (string code)
        {                                   
            return Ok(_service.Get(code));
        }

        [Route("{code}")]
        [HttpDelete]
        public ActionResult<StockResponse> Delete(string code)
        {
            return _service.Delete(code);
        }
    }
}
