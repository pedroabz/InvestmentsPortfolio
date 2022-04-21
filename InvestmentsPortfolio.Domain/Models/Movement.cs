namespace InvestmentsPortfolio.Domain.Models
{
    public abstract class Movement : BaseEntity
    {
        public int Quantity { get; }
        public decimal AverageValue { get; }
        public string Currency { get; }
        public Movement() : base()
        {

        }
    }
}
