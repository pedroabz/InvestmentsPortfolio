using InvestmentsPortfolioAPI.Application.DTO;
using InvestmentsPortfolioAPI.Domain.Models;

namespace InvestmentsPortfolioAPI.Application.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToDto(this Stock stock)
        {
            return new StockDTO(stock.Code, stock.Name);
        }

        public static Stock ToModel(this StockDTO stock)
        {
            return new Stock(stock.Code, stock.Name);
        }
    }
}
