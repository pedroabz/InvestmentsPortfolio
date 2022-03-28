namespace InvestmentsPortfolio.Domain.Models
{
    public class Stock : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Stock() : base()
        {
        }

        public Stock(string code, string name) : base()
        {
            Code = code;
            Name = name;
        }
    }
    
}
