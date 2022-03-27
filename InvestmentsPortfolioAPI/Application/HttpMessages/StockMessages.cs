namespace InvestmentsPortfolioAPI.Application.HttpMessages
{
    public static class StockMessages
    {
        public static string NoStockWithThisCode => "There is no stock registered with this code";
        public static string StockAlreadyExists => "There is already a Stock registered with this code";
    }
}
