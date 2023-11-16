using InvestimentSimulator.WebAPI.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestimentSimulator.WebAPI.Tests.Application.Services
{
    [TestClass]
    public class InvestmentServiceTest
    {
        private InvestmentService _investmentService;

        public class TestableInvestmentService : InvestmentService
        {
            public TestableInvestmentService() : base() { }
        }

        [TestInitialize]
        public void Setup()
        {
            _investmentService = new TestableInvestmentService();
        }

        [TestMethod]
        public void CalculateTaxIR_LessThanOrEqual6Months_ReturnsCorrectTax()
        {
            // Arrange
            decimal amount = 1000;
            int months = 6;

            // Act
            var result = _investmentService.CalculateTaxIR(amount, months);

            // Assert
            Assert.AreEqual(amount * 0.225m, result);
        }

        [TestMethod]
        public void CalculateTaxIR_LessThanOrEqual12Months_ReturnsCorrectTax()
        {
            // Arrange
            decimal amount = 1000;
            int months = 9;

            // Act
            var result = _investmentService.CalculateTaxIR(amount, months);

            // Assert
            Assert.AreEqual(amount * 0.20m, result);
        }

        [TestMethod]
        public void CalculateTaxIR_LessThanOrEqual24Months_ReturnsCorrectTax()
        {
            // Arrange
            decimal amount = 1000;
            int months = 18;

            // Act
            var result = _investmentService.CalculateTaxIR(amount, months);

            // Assert
            Assert.AreEqual(amount * 0.175m, result);
        }

        [TestMethod]
        public void CalculateTaxIR_MoreThan24Months_ReturnsCorrectTax()
        {
            // Arrange
            decimal amount = 1000;
            int months = 36;

            // Act
            var result = _investmentService.CalculateTaxIR(amount, months);

            // Assert
            Assert.AreEqual(amount * 0.15m, result);
        }
    }
}
