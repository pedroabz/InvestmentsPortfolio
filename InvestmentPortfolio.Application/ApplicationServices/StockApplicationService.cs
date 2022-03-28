using InvestmentsPortfolio.Application.ApplicationServices.Interfaces;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using InvestmentsPortfolioAPI.HttpMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.ApplicationServices
{
    public class StockApplicationService : IStockApplicationService
    {
        public readonly IRepository<Stock> _stockRepository;
        public StockApplicationService(IRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        StockResponse IStockApplicationService.CreateStock(StockRequest newStock)
        {
            if (_stockRepository.FirstOrDefault(x => x.Code == newStock.Code) != null)
                throw new BadRequestException(StockMessages.StockAlreadyExists);
            return _stockRepository.Create(newStock.ToModel()).ToResponse();            
        }

        StockResponse IStockApplicationService.Delete(string code)
        {
            var stockToDelete = _stockRepository.FirstOrDefault(x => x.Code == code);
            if (stockToDelete == null)
                throw new EntityNotFoundException(StockMessages.NoStockWithThisCode);
            _stockRepository.Delete(stockToDelete);
            return stockToDelete.ToResponse();
        }

        StockResponse IStockApplicationService.GetStock(string code)
        {
            var stock = _stockRepository.FirstOrDefault(x => x.Code == code);
            if (stock == null)
                throw new EntityNotFoundException(StockMessages.NoStockWithThisCode);
            return stock.ToResponse();
        }
    }
}
