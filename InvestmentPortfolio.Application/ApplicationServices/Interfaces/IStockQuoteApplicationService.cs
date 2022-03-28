using InvestmentsPortfolio.Application.DTO;
using System;
using System.Collections.Generic;

namespace InvestmentsPortfolio.Application.ApplicationServices
{
    public interface IStockQuoteApplicationService
    {    
        public IEnumerable<StockQuoteRequest> GetAllStocksQuoteByDate(DateTime day);
        public StockQuoteRequest GetStockQuote(DateTime day, string Code);
        public StockQuoteRequest GetStockQuoteHistory(DateTime beginDay, DateTime endDate, string code);
        public void CreateNewStocksQuotes(List<StockQuoteRequest> stock);
        public StockQuoteRequest UpdateStockQuote (StockQuoteRequest day, string Code);
        public void DeleteStockQuote (DateTime day, string code);
    }
}