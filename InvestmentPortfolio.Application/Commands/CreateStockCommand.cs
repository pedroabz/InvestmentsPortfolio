using InvestmentsPortfolio.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.Commands
{
    public class CreateStockCommand : IRequest <StockResponse>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public CreateStockCommand()
        {}

        public CreateStockCommand(string code, string name) : base()
        {
            Code = code;
            Name = name;
        }
    }
}
