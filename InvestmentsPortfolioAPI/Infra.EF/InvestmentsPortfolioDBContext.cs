using InvestmentsPortfolioAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentsPortfolioAPI.Infra.EF
{
    public class InvestmentsPortfolioDBContext : DbContext
    {
        public virtual DbSet<Stock> Stock { get; set; }
        public InvestmentsPortfolioDBContext(DbContextOptions<InvestmentsPortfolioDBContext> options) : base(options)
        {}

    }
}
