using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Application.Queries;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using InvestmentsPortfolioAPI.HttpMessages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentsPortfolio.Application.Handlers
{
    public class GetStockHandler : IRequestHandler<GetStockQuery, StockResponse>
    {
        private readonly IRepository<Stock> _stockRepository;

        public GetStockHandler(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockResponse> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stock = _stockRepository.FirstOrDefault(x => x.Code == request.Code);
            if (stock == null)
                throw new EntityNotFoundException(StockMessages.NoStockWithThisCode);
            return await Task.Run(() => stock.ToResponse());
        }
    }
}
