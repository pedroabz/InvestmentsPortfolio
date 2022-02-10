using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentsPortfolioAPI.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Quantity { get; set; }
        public Stock()
        {
        }


        public Stock(string code, decimal unitValue, decimal quantity)
        {
            Code = code;
            UnitValue = unitValue;
            Quantity = quantity;
        }
    }
}
