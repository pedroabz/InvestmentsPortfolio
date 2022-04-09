using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentsPortfolio.Application.ApplicationServices.Interfaces
{
    public interface IStockApplicationService
    {
        StockResponse Create(StockRequest newStock);
        StockResponse Delete(string code);
        StockResponse Get(string code);
    }
}
