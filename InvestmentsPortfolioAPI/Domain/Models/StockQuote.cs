using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentsPortfolioAPI.Domain.Models
{
    public class StockQuote : BaseEntity
    {
        public Stock Stock { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal UnitValue { get; set; }
        public StockQuote()
        {
        }

        public StockQuote(Stock stock, decimal unitValue, DateTime quoteDate) : base()
        {
            Stock = stock;
            UnitValue = unitValue;
            QuoteDate = quoteDate;
        }
    }
}
