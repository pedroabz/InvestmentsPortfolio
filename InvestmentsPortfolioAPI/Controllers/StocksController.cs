using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestmentsPortfolioAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class StocksController : ControllerBase
    {

        private readonly ILogger<StocksController> _logger;
        public readonly IRepository<Stock> _stockRepository;

        public StocksController(ILogger<StocksController> logger, IRepository<Stock> stock)
        {
            _logger = logger;
            _stockRepository = stock;
        }

        /// <summary>
        /// GET a list of strings
        /// </summary>
        /// <returns code="200"> Returns a list of strings </returns>
        [HttpGet]
        public IEnumerable<Stock> GetAll()
        {
            return _stockRepository.All();
        }

        [HttpPost]
        public IActionResult Post ([FromBody] List<Stock> stock)
        {
            _stockRepository.Create(stock);
            return Ok();
        }
    }
}
