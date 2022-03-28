using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Mappers;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentsPortfolio.Application.ApplicationServices
{
    public class StockQuoteApplicationService : IStockQuoteApplicationService
    {
        public readonly IRepository<StockQuote> _stockRepository;
        public StockQuoteApplicationService(IRepository<StockQuote> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void CreateNewStocksQuotes(List<StockQuoteRequest> stock)
        {
            _stockRepository.Create(stock.Select(x => x.ToModel()).ToList());            
        }

        public void DeleteStockQuote(DateTime day, string code)
        {
            var stockQuote = _stockRepository.FirstOrDefault(x => x.QuoteDate == day && x.Stock.Code == code);
            _stockRepository.Delete(stockQuote);
        }

        public IEnumerable<StockQuoteRequest> GetAllStocksQuoteByDate(DateTime day)
        {
            return _stockRepository.Where(x => x.QuoteDate == day).Select(x => x.ToDto());
        }

        public StockQuoteRequest GetStockQuote(DateTime day, string code)
        {
            return _stockRepository.FirstOrDefault(x => x.QuoteDate == day && x.Stock.Code == code).ToDto();
        }

        public StockQuoteRequest GetStockQuoteHistory(DateTime beginDay, DateTime endDate, string code)
        {
            throw new NotImplementedException();
        }

        public StockQuoteRequest UpdateStockQuote(StockQuoteRequest day, string Code)
        {
            throw new NotImplementedException();
        }
    }
}
