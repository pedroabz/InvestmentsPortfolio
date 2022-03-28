namespace InvestmentsPortfolio.Domain.Models
{
    public abstract class Movement : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal AverageValue { get; set; }
        public string Currency { get; set; }
        public Movement() : base()
        {

        }
    }
}
