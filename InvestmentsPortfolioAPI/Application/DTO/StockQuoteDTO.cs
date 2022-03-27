using System;

namespace InvestmentsPortfolioAPI.Application.DTO
{
    public class StockQuoteDTO
    {
        public StockQuoteDTO(string code, DateTime quoteDate, decimal unitValue)
        {
            Code = code;
            QuoteDate = quoteDate;
            UnitValue = unitValue;
        }

        public StockQuoteDTO()
        {

        }

        public string Code { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal UnitValue { get; set; }
    }
}
