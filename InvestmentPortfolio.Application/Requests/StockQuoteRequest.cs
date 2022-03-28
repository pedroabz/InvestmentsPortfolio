using System;

namespace InvestmentsPortfolio.Application.DTO
{
    public class StockQuoteRequest
    {
        public StockQuoteRequest(string code, DateTime quoteDate, decimal unitValue)
        {
            Code = code;
            QuoteDate = quoteDate;
            UnitValue = unitValue;
        }

        public StockQuoteRequest()
        {

        }

        public string Code { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal UnitValue { get; set; }
    }
}
