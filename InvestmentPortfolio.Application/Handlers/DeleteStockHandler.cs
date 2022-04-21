using InvestmentsPortfolio.Application.Commands;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using InvestmentsPortfolioAPI.HttpMessages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentsPortfolio.Application.Handlers
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand, StockResponse>
    {
        private readonly IRepository<Stock> _stockRepository;

        public DeleteStockHandler(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Task<StockResponse> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stockToDelete = _stockRepository.FirstOrDefault(x => x.Code == request.Code);
            if (stockToDelete == null)
                throw new EntityNotFoundException(StockMessages.NoStockWithThisCode);
            _stockRepository.Delete(stockToDelete);
            return Task.Run(() => stockToDelete.ToResponse());
        }
    }
}
