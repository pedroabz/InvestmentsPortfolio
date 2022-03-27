namespace InvestmentsPortfolioAPI.Application.DTO
{
    public class StockDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public StockDTO()
        {

        }

        public StockDTO(string code, string name) : base()
        {
            Code = code;
            Name = name;
        }
    }
}
