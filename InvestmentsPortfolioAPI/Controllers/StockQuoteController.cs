using System;
using System.Collections.Generic;
using System.Linq;
using InvestmentsPortfolio.Application.ApplicationServices;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestmentsPortfolioAPI.Controllers
{  
    //TODO: Soft Delete nas classes https://www.thereformedprogrammer.net/ef-core-in-depth-soft-deleting-data-with-global-query-filters/#:~:text=You%20can%20add%20a%20soft,restored%20and%20history%20is%20preserved.
    //TODO: Implementar  Testes Unitários
    //TODO: Implementar Swagger bem documentado
    //TODO: Implementar busca em API para cotação dólar real
    //TODO: Investigar Automapper (provavelmente farei no projeto CSharpResources)
    //TODO: Implementar Compra de ação para portfolio
    //TODO: Implementar cadastro de usuários e roles com a data annotation [Authorize]
    //TODO: Implementar método GetPosition(Date PositionDate)
    //TODO: Implementar Factory para criar buy ou sell para Movement
    //TODO: Implementar Mediatr https://balta.io/blog/aspnet-core-cqrs-mediator
    public class StockQuoteController : BaseController
    {
        public readonly IRepository<StockQuote> _stockRepository;
        public readonly IStockQuoteApplicationService _stockApplicationService;

        public StockQuoteController(IRepository<StockQuote> stock, IStockQuoteApplicationService stockApplicationService)
        {
            _stockRepository = stock;
            _stockApplicationService = stockApplicationService;
        }

        /// <summary>
        /// GET a list of strings
        /// </summary>
        /// <returns code="200"> Returns a list of strings </returns>
        [HttpGet]
        public IActionResult GetAllStockQuoteByDate(DateTime day)
        {
            return Ok(_stockApplicationService.GetAllStocksQuoteByDate(day));
        }

        /// <summary>
        /// GET a a Stock
        /// </summary>
        /// <returns code="200"> Returns a list of strings </returns>
        [Route ("GetFirst/{code}/{date}")]
        [ProducesResponseType(typeof(List<StockQuoteRequest>), 200)]
        [HttpGet]
        public IActionResult GetStockQuoteByDay(string code, DateTime date)
        {
            return new OkObjectResult(_stockApplicationService.GetStockQuote(date, code));
        }

        [HttpPost]
        public IActionResult Post ([FromBody] List<StockQuoteRequest> stock)
        {
            _stockApplicationService.CreateNewStocksQuotes(stock);
            return Ok();
        }

        [Route("{code}/{date}")]
        [HttpDelete]
        public IActionResult Delete(string code, DateTime date)
        {
            _stockApplicationService.DeleteStockQuote(date, code);
            return Ok();
        }
    }
}
