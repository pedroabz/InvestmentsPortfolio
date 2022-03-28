using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.Response
{
    public class StockResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }        

        public StockResponse()
        {

        }

        public StockResponse(string code, string name, int id)
        {
            Code = code;
            Name = name;
            Id = id;
        }
    }
}
