using InvestmentsPortfolioAPI.Application.DTO;
using InvestmentsPortfolioAPI.Domain.Models;

namespace InvestmentsPortfolioAPI.Application.Mappers
{
    public static class StockQuoteMapper
    {
        public static StockQuoteDTO ToDto(this StockQuote stockQuote)
        {
            return new StockQuoteDTO (stockQuote.Stock.Code, stockQuote.QuoteDate, stockQuote.UnitValue);
        }

        public static StockQuote ToModel(this StockQuoteDTO stockQuote)
        {
            // return new StockQuote (stockQuote.UnitValue, stockQuote.QuoteDate);
            return new StockQuote();
        }
    }
}
