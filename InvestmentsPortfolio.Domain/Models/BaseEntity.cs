using System;

namespace InvestmentsPortfolio.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; private set; }
        public BaseEntity()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
