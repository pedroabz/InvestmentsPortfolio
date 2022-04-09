using FluentAssertions;
using InvestmentsPortfolio.Application.ApplicationServices;
using InvestmentsPortfolio.Application.ApplicationServices.Interfaces;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolio.Infra.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InvestimentsPortfolio.Tests.ApplicationTests
{
    [TestClass]
    public class StockApplicationServiceTests : BaseDbTests
    {
        private IStockApplicationService _applicationservice;
        private IRepository<Stock> _repository; 
        public StockApplicationServiceTests() : base()
        {

        }
        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            _services.AddScoped<IStockApplicationService, StockApplicationService>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<IRepository<Stock>>();
            _applicationservice = serviceProvider.GetService<IStockApplicationService>();
        }

        [ExpectedException(typeof(BadRequestException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenCreatingStockThatExists()
        {
            _repository.Create(new Stock("TT", "test"));
            var newStockRequest = new StockRequest("TT", "test2");
            _applicationservice.Create(newStockRequest);
        }

        [TestMethod]
        public void ShouldCreateStock()
        {;
            var newStockRequest = new StockRequest("TT", "test2");
            _applicationservice.Create(newStockRequest);
            var createdStock = _repository.FirstOrDefault(x => x.Code == newStockRequest.Code);
            createdStock.Name.Should().Be("test2");
            createdStock.Code.Should().Be("TT");
        }
        [TestMethod]
        public void ShouldGetStock()
        {
            _repository.Create(new Stock("TT", "test"));
            throw new NotImplementedException();
        }
        [TestMethod]
        public void ShouldDeleteStock()
        {
            _repository.Create(new Stock("TT", "test"));
            throw new NotImplementedException();
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenDeletingStockThatDoesNotExist()
        {
            _applicationservice.Delete("NonExistant");
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenGettingStockThatDoesNotExist()
        {
            _applicationservice.Get("NonExistant");
        }
    }
}
