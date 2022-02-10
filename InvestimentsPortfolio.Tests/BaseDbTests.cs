using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestimentsPortfolio.Tests
{
    [TestClass]
    public abstract class BaseDbTests
    {
        protected InvestmentsPortfolioDBContext _dbContext;
        protected readonly ServiceCollection _services = new ServiceCollection();

        public virtual void SetupDBTestDependencies(string dbName = null)
        {           
            _services
                .AddDbContext<InvestmentsPortfolioDBContext>(options => 
                    options
                        .UseInMemoryDatabase(databaseName: dbName ?? Guid.NewGuid().ToString())
                );
        }

    }
}
