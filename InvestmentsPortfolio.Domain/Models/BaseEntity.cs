using System;

namespace InvestmentsPortfolio.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; }
        public BaseEntity()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
