using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Domain.Models;

namespace InvestmentsPortfolio.Application.Mappers
{
    public static class StockQuoteMapper
    {
        public static StockQuoteRequest ToDto(this StockQuote stockQuote)
        {
            return new StockQuoteRequest (stockQuote.Stock.Code, stockQuote.QuoteDate, stockQuote.UnitValue);
        }

        public static StockQuote ToModel(this StockQuoteRequest stockQuote)
        {
            // return new StockQuote (stockQuote.UnitValue, stockQuote.QuoteDate);
            return new StockQuote();
        }
    }
}
