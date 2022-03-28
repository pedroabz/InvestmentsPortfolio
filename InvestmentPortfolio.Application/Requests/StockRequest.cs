namespace InvestmentsPortfolio.Application.DTO
{
    public class StockRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public StockRequest()
        {

        }

        public StockRequest(string code, string name) : base()
        {
            Code = code;
            Name = name;
        }
    }
}
