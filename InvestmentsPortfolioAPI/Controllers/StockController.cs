using InvestmentsPortfolio.Application.Commands;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Application.Queries;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using InvestmentsPortfolioAPI.HttpMessages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvestmentsPortfolioAPI.Controllers
{

    public class StockController : BaseController
    {
        private readonly IMediator _mediator;

        public StockController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<StockResponse>> Post([FromBody] CreateStockCommand newStock)
        {
            return await _mediator.Send(newStock);
        }

        [Route ("{code}")]
        [HttpGet]
        public async Task<IActionResult> Get (string code)
        {
            var stockQuery = new GetStockQuery(code);
            var result = await _mediator.Send(stockQuery);
            return Ok(result);
        }

        [Route("{code}")]
        [HttpDelete]
        public async Task<ActionResult<StockResponse>> Delete(string code)
        {
            var deleteCommand = new DeleteStockCommand(code);
            var result = await _mediator.Send(deleteCommand);
            return Ok(result);
        }
    }
}
