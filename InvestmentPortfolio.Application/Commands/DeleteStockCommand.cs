using InvestmentsPortfolio.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.Commands
{
    public class DeleteStockCommand : IRequest <StockResponse>
    {
        public string Code { get; set; }

        public DeleteStockCommand(string code) : base()
        {
            Code = code;
        }
    }
}
