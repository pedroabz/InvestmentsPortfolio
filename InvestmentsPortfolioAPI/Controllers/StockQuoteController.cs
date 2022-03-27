﻿using System;
using System.Collections.Generic;
using System.Linq;
using InvestmentsPortfolioAPI.Application.ApplicationServices;
using InvestmentsPortfolioAPI.Application.DTO;
using InvestmentsPortfolioAPI.Application.Mappers;
using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestmentsPortfolioAPI.Controllers
{
    [ApiController]
    //TODO: Implementar Exceptions
    //TODO: Mudar lógicas nos controllers p/ applications
    //TODO: Mudar Exceptions para error middleware --> https://jasonwatmore.com/post/2020/10/02/aspnet-core-31-global-error-handler-tutorial
    //TODO: Soft Delete nas classes https://www.thereformedprogrammer.net/ef-core-in-depth-soft-deleting-data-with-global-query-filters/#:~:text=You%20can%20add%20a%20soft,restored%20and%20history%20is%20preserved.
    //TODO: Separa Classe Stock, StockQuote, User e StockUserAggregate
    //TODO: Implementar Swagger bem documentado
    //TODO: Implementar busca em API para cotação dólar real
    //TODO: Investigar Automapper (provavelmente farei no projeto CSharpResources)
    //TODO: Implementar Compra de ação para portfolio
    //TODO: Implementar cadastro de usuários e roles com a data annotation [Authorize]
    //TODO: Implementar método GetPosition(Date PositionDate)
    //TODO: Implementar Factory para criar buy ou sell para Movement

    [Route("[controller]")]
    public class StockQuoteController : ControllerBase
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
        [ProducesResponseType(typeof(List<StockQuoteDTO>), 200)]
        [HttpGet]
        public IActionResult GetStockQuoteByDay(string code, DateTime date)
        {
            return new OkObjectResult(_stockApplicationService.GetStockQuote(date, code));
        }

        [HttpPost]
        public IActionResult Post ([FromBody] List<StockQuoteDTO> stock)
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