using InvestimentSimulator.WebAPI.Application.Services;
using InvestimentSimulator.WebAPI.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestimentSimulator.WebAPI.Tests.Application.Services
{
    [TestClass]
    public class CdbInvestimentServiceTest
    {
        private CdbInvestimentService _cdbInvestimentService;

        [TestInitialize]
        public void Setup()
        {
            _cdbInvestimentService = new CdbInvestimentService();
        }

        [TestMethod]
        public void CalculateInvestment_ValidInvestment_ReturnsCorrectInvestmentResponse()
        {
            // Arrange
            var validInvestment = new Investment { Amount = 500, Months = 2 };

            // Act
            var result = _cdbInvestimentService.CalculateInvestment(validInvestment);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvestmentResponse));
            Assert.AreEqual(509.77m, result.GrossAmount);
            Assert.AreEqual(507.57m, result.NetAmount);
        }

    }
}
