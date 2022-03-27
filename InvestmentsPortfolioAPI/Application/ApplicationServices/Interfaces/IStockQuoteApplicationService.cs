using InvestmentsPortfolioAPI.Application.DTO;
using System;
using System.Collections.Generic;

namespace InvestmentsPortfolioAPI.Application.ApplicationServices
{
    public interface IStockQuoteApplicationService
    {    
        public IEnumerable<StockQuoteDTO> GetAllStocksQuoteByDate(DateTime day);
        public StockQuoteDTO GetStockQuote(DateTime day, string Code);
        public StockQuoteDTO GetStockQuoteHistory(DateTime beginDay, DateTime endDate, string code);
        public void CreateNewStocksQuotes(List<StockQuoteDTO> stock);
        public StockQuoteDTO UpdateStockQuote (StockQuoteDTO day, string Code);
        public void DeleteStockQuote (DateTime day, string code);
    }
}