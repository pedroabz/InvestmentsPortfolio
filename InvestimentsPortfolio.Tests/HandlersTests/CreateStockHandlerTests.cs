using FluentAssertions;
using InvestmentsPortfolio.Application.Commands;
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

namespace InvestimentsPortfolio.Tests.HandlersTests
{
    [TestClass]
    public class CreateStockHandlerTests : BaseDbTests
    {
        private IRepository<Stock> _repository;
        private CreateStockHandler _handler;
        public CreateStockHandlerTests() : base()
        {

        }
        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<IRepository<Stock>>();
            _handler = new CreateStockHandler(_repository);
        }

        [ExpectedException(typeof(BadRequestException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenCreatingStockThatExists()
        {
            _repository.Create(new Stock("TT", "test"));
            var newStockRequest = new CreateStockCommand("TT", "test2");
            _handler.Handle(newStockRequest, new CancellationToken()).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void ShouldCreateStock()
        {
            var newStockRequest = new CreateStockCommand("TT", "test2");
            var createdStockResponse = _handler.Handle(newStockRequest, new CancellationToken()).GetAwaiter().GetResult();
            createdStockResponse.Should().BeEquivalentTo(new StockResponse {
                Code = "TT",
                Name = "test2"
            }, options => options.Excluding(x => x.Id));
            
        }       
    }
}
