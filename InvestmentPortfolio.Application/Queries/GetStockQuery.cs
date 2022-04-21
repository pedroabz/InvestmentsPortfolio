using InvestmentsPortfolio.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.Queries
{
    public class GetStockQuery : IRequest<StockResponse>
    {
        public GetStockQuery(string code)
        {
            Code = code;
        }
        public GetStockQuery()
        {

        }

        public string Code { get; set; }
    }
}
