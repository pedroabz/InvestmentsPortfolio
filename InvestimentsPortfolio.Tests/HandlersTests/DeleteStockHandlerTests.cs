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
    public class DeleteStockHandlerTests : BaseDbTests
    {
        private IRepository<Stock> _repository;
        private DeleteStockHandler _handler;
        public DeleteStockHandlerTests() : base()
        {

        }
        [TestInitialize]
        public void Setup()
        {
            _services.AddScoped<IRepository<Stock>, Repository<Stock>>();
            base.SetupDBTestDependencies();
            var serviceProvider = _services.BuildServiceProvider();
            _repository = serviceProvider.GetService<IRepository<Stock>>();
            _handler = new DeleteStockHandler(_repository);
        }

       
        [TestMethod]
        public void ShouldDeleteStock()
        {
           _repository.Create(new Stock("TT", "test"));
            var deletedStockResponse = _handler.Handle(new DeleteStockCommand("TT"), new CancellationToken()).GetAwaiter().GetResult();
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
            _handler.Handle(new DeleteStockCommand("NonExistant"), new CancellationToken()).GetAwaiter().GetResult();
        }
    }
}
