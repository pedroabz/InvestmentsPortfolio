using InvestmentsPortfolioAPI.Application.DTO;
using InvestmentsPortfolioAPI.Application.Mappers;
using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentsPortfolioAPI.Application.ApplicationServices
{
    public class StockQuoteApplicationService : IStockQuoteApplicationService
    {
        public readonly IRepository<StockQuote> _stockRepository;
        public StockQuoteApplicationService(IRepository<StockQuote> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void CreateNewStocksQuotes(List<StockQuoteDTO> stock)
        {
            _stockRepository.Create(stock.Select(x => x.ToModel()).ToList());            
        }

        public void DeleteStockQuote(DateTime day, string code)
        {
            var stockQuote = _stockRepository.FirstOrDefault(x => x.QuoteDate == day && x.Stock.Code == code);
            _stockRepository.Delete(stockQuote);
        }

        public IEnumerable<StockQuoteDTO> GetAllStocksQuoteByDate(DateTime day)
        {
            return _stockRepository.Where(x => x.QuoteDate == day).Select(x => x.ToDto());
        }

        public StockQuoteDTO GetStockQuote(DateTime day, string code)
        {
            return _stockRepository.FirstOrDefault(x => x.QuoteDate == day && x.Stock.Code == code).ToDto();
        }

        public StockQuoteDTO GetStockQuoteHistory(DateTime beginDay, DateTime endDate, string code)
        {
            throw new NotImplementedException();
        }

        public StockQuoteDTO UpdateStockQuote(StockQuoteDTO day, string Code)
        {
            throw new NotImplementedException();
        }
    }
}
