namespace InvestmentsPortfolio.Domain.Models
{
    public class Stock : BaseEntity
    {
        public string Code { get; private set; }
        public string Name { get; }
        private Stock() : base()
        {
        }

        public Stock(string code, string name) : base()
        {
            Code = code;
            Name = name;
        }
    }
    
}
