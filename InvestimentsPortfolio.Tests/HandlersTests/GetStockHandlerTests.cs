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

namespace InvestimentsPortfolio.Tests.ApplicationTests
{
    [TestClass]
    public class GetStockHandlerTests : BaseDbTests
    {
        private IRepository<Stock> _repository;
        private GetStockHandler _handler ;
        public GetStockHandlerTests() : base()
        {

        }
        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<IRepository<Stock>>();
            _handler = new GetStockHandler(_repository);
        }

        
        [TestMethod]
        public void ShouldGetStock()
        {           
            var createdStock = _repository.Create(new Stock("TT", "test"));
            var result = _handler.Handle(new GetStockQuery("TT"), new CancellationToken()).GetAwaiter().GetResult();
            result.Should().BeEquivalentTo(new StockResponse("TT", "test", createdStock.Id));           
        }
      

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenGettingStockThatDoesNotExist()
        {
            _handler.Handle(new GetStockQuery("NonExistant"), new System.Threading.CancellationToken()).GetAwaiter().GetResult();
        }
    }
}
