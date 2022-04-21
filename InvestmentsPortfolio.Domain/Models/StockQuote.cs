using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentsPortfolio.Domain.Models
{
    public class StockQuote : BaseEntity
    {
        public Stock Stock { get; }
        public DateTime QuoteDate { get; private set; }
        public decimal UnitValue { get; }
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
