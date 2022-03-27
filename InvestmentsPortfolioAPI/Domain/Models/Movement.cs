namespace InvestmentsPortfolioAPI.Domain.Models
{
    public abstract class Movement : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal AverageValue { get; set; }
        public Movement() : base()
        {

        }
    }
}
