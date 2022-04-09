using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolioAPI.Infra.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System.Linq;
using InvestmentsPortfolio.Infra.Repositories;

namespace InvestimentsPortfolio.Tests
{

    [TestClass]
    public class StockRepositoryTests : BaseDbTests
    {

        public StockRepositoryTests() : base()
        {

        }

        private Repository<StockQuote> _repository;

        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<Repository<StockQuote>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<Repository<StockQuote>>();

        }

        [TestMethod]
        public void ShouldReturnAllStocks()
        {
            var stocks = new List<StockQuote> {
                //new StockQuote("VT", 123.5M, DateTime.Today),
                //new StockQuote("SLYV", 523.5M, DateTime.Today),
                //new StockQuote("DGS", 45.3M, DateTime.Today),
                //new StockQuote("VT", 120.5M, DateTime.Today.AddDays(-1)),
                //new StockQuote("SLYV", 483.5M, DateTime.Today.AddDays(-1)),
                //new StockQuote("DGS", 55.3M, DateTime.Today.AddDays(-1))
                };
            SeedDataBase();
            var allStocks = _repository.All();
            allStocks.Should().BeEquivalentTo(stocks,
                options => options.Excluding(x => x.Id));
        }


        [DataRow("VT", 123.5)]
        [DataRow("SLYV", 523.5)]
        [DataRow("DGS", 45.3)]
        //[TestMethod]
        public void ShouldReturnStockFromToday(string code, double unitValue)
        {
            
            //SeedDataBase();
            //var vtToday = _repository.FirstOrDefault(x => x.Stock.Code == code && x.QuoteDate == DateTime.Today);
            //vtToday.Should().BeOfType<StockQuote>();
            //vtToday.Should().BeEquivalentTo(new StockQuote(code,(decimal) unitValue, DateTime.Today),
            //    options => options.Excluding(x => x.Id)
            //);           
        }

        [TestMethod]
        public void ShouldReturnListOfTodayStocks()
        {
            SeedDataBase();
            var todayStocks = _repository.Where(x => x.QuoteDate == DateTime.Today) ;
            todayStocks.Select(x => x.QuoteDate).Should().AllBeEquivalentTo(DateTime.Today);
        }

        //[TestMethod]
        public void ShouldUpdateUnitValue()
        {
            //SeedDataBase();
            //var stock = _repository.FirstOrDefault(x => x.QuoteDate == DateTime.Today && x.Stock.Code == "VT");
            //stock.UnitValue += 100;
            //_repository.Update(stock);
            //var newStock = _repository.FirstOrDefault(x => x.QuoteDate == DateTime.Today && x.Stock.Code == "VT");
            //newStock.UnitValue.Should().Be(223.5M);
        }

        private void SeedDataBase()
        {
            var stocks = new List<StockQuote> {
                //new StockQuote("VT", 123.5M, DateTime.Today),
                //new StockQuote("SLYV", 523.5M, DateTime.Today),
                //new StockQuote("DGS", 45.3M, DateTime.Today),
                //new StockQuote("VT", 120.5M, DateTime.Today.AddDays(-1)),
                //new StockQuote("SLYV", 483.5M, DateTime.Today.AddDays(-1)),
                //new StockQuote("DGS", 55.3M, DateTime.Today.AddDays(-1))
                };

                _repository.Create(stocks);
            }
        

    }
}
