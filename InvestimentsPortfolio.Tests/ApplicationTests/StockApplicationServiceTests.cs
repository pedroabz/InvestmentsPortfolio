using FluentAssertions;
using InvestmentsPortfolio.Application.ApplicationServices;
using InvestmentsPortfolio.Application.Commands;
using InvestmentsPortfolio.Application.DTO;
using InvestmentsPortfolio.Application.Handlers;
using InvestmentsPortfolio.Application.Queries;
using InvestmentsPortfolio.Application.Response;
using InvestmentsPortfolio.Domain.Models;
using InvestmentsPortfolio.Domain.Repositories;
using InvestmentsPortfolio.Infra.Repositories;
using InvestmentsPortfolioAPI.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvestimentsPortfolio.Tests.ApplicationTests
{
    [TestClass]
    public class StockApplicationServiceTests : BaseDbTests
    {
        private IRepository<Stock> _repository; 
        public StockApplicationServiceTests() : base()
        {

        }
        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<IRepository<Stock>>();
        }

        [ExpectedException(typeof(BadRequestException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenCreatingStockThatExists()
        {
            var handler = new CreateStockHandler(_repository);
            _repository.Create(new Stock("TT", "test"));
            var newStockRequest = new CreateStockCommand("TT", "test2");
            handler.Handle(newStockRequest, new CancellationToken()).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ShouldCreateStock()
        {
            var handler = new CreateStockHandler(_repository);
            var newStockRequest = new CreateStockCommand("TT", "test2");
            var createdStockResponse = handler.Handle(newStockRequest, new CancellationToken()).GetAwaiter().GetResult();
            createdStockResponse.Should().BeEquivalentTo(new StockResponse {
                Code = "TT",
                Name = "test2"
            }, options => options.Excluding(x => x.Id));
            
        }
        [TestMethod]
        public void ShouldGetStock()
        {
            var handler = new GetStockHandler(_repository);
            var createdStock = _repository.Create(new Stock("TT", "test"));
            var result = handler.Handle(new GetStockQuery("TT"), new CancellationToken()).GetAwaiter().GetResult();
            result.Should().BeEquivalentTo(new StockResponse("TT", "test", createdStock.Id));           
        }
        [TestMethod]
        public void ShouldDeleteStock()
        {
            var handler = new DeleteStockHandler(_repository);
           _repository.Create(new Stock("TT", "test"));
            var deletedStockResponse = handler.Handle(new DeleteStockCommand("TT"), new CancellationToken()).GetAwaiter().GetResult();
            deletedStockResponse.Should().BeEquivalentTo(new StockResponse
           {
               Code = "TT",
               Name = "test"
           }, options => options.Excluding(x => x.Id)); 
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenDeletingStockThatDoesNotExist()
        {
            var handler = new DeleteStockHandler(_repository);            
            var deletedStockResponse = handler.Handle(new DeleteStockCommand("NonExistant"), new CancellationToken()).GetAwaiter().GetResult();
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenGettingStockThatDoesNotExist()
        {
            var handler = new GetStockHandler(_repository);
            handler.Handle(new GetStockQuery("NonExistant"), new System.Threading.CancellationToken()).GetAwaiter().GetResult();
        }
    }
}
