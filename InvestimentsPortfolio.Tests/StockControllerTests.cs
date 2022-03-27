using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestimentsPortfolio.Tests
{
    [TestClass]
    public class StockControllerTests : BaseDbTests
    {
        public StockControllerTests() : base()
        {

        }

        private Repository<Stock> _repository;

        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<Repository<Stock>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<Repository<Stock>>();
        }
    }
}
