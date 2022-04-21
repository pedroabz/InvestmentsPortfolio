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
    public class CreateStockHandler : IRequestHandler<CreateStockCommand, StockResponse>
    {
        private readonly IRepository<Stock> _stockRepository;

        public CreateStockHandler(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Task<StockResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            if (_stockRepository.FirstOrDefault(x => x.Code == request.Code) != null)
                throw new BadRequestException(StockMessages.StockAlreadyExists);
            return Task.Run(() => _stockRepository.Create(request.ToModel()).ToResponse());
        }
    }
}
