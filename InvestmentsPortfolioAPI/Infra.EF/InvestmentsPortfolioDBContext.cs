using InvestmentsPortfolioAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace InvestmentsPortfolioAPI.Infra.EF
{
    public class InvestmentsPortfolioDBContext : DbContext
    {
        public virtual DbSet<StockQuote> StockQuote { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<User> User { get; set; }
        
        public InvestmentsPortfolioDBContext(DbContextOptions<InvestmentsPortfolioDBContext> options) : base(options)
        {
        }

    }
}
