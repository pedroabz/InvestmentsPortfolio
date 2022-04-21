using InvestmentsPortfolio.Application.Commands;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;

namespace InvestmentsPortfolio.Application.Mappers
{
    public static class StockMapper
    {
        public static StockResponse ToResponse(this Stock stock)
        {
            return new StockResponse(stock.Code, stock.Name, stock.Id);
        }

        public static Stock ToModel(this CreateStockCommand stock)
        {
            return new Stock(stock.Code, stock.Name);
        }
    }
}
