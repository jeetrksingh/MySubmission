using System;
using System.Threading.Tasks;
using CrossExchange.Controller;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;

namespace CrossExchange.Tests
{
    public class TradeControllerTests
    {
        private readonly Mock<IShareRepository> _shareRepositoryMock = new Mock<IShareRepository>();
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new Mock<ITradeRepository>();
        private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock = new Mock<IPortfolioRepository>();
        
        private readonly TradeController _tradeController;        

        public TradeControllerTests()
        {
            _tradeController = new TradeController(_shareRepositoryMock.Object,_tradeRepositoryMock.Object, _portfolioRepositoryMock.Object);
        }

        [Test]
        public async Task Post_TradeMethod()
        {
            var trade = new TradeModel
            {
                Symbol = "CBI",
                NoOfShares = 4,                
                PortfolioId =1,
                Action = "SELL"
            };

            var result = await _tradeController.Post(trade);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
        }

    }
}
