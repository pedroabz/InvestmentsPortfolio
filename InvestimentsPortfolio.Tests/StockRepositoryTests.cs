using InvestmentsPortfolioAPI.Domain.Models;
using InvestmentsPortfolioAPI.Domain.Repositories;
using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace InvestimentsPortfolio.Tests
{

    [TestClass]
    public class StockRepositoryTests : BaseDbTests
    {

        public StockRepositoryTests() : base()
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

        [TestMethod]
        public void ShouldReturnAllStocks()
        {
            var listStocks = new List<Stock> { new Stock("VT", 123.5M, 4367.3M), new Stock("SLYV", 523.5M, 9997.3M) };
            _repository.Create(listStocks);
            var allStocks = _repository.All();
            allStocks.Should().BeEquivalentTo(listStocks);
        }
    }
}
