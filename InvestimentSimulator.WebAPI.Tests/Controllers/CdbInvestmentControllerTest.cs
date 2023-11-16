using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using InvestimentSimulator.WebAPI.Application.Services;
using InvestimentSimulator.WebAPI.Controllers;
using InvestimentSimulator.WebAPI.Core.Entities;
using InvestimentSimulator.WebAPI.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InvestimentSimulator.WebAPI.Tests.Controllers
{
    [TestClass]
    public class CdbInvestmentControllerTest
    {
        private CdbInvestmentController _controller;
        private Mock<ICdbInvestimentService> _mockCdbInvestmentService;

        [TestInitialize]
        public void Setup()
        {
            _mockCdbInvestmentService = new Mock<ICdbInvestimentService>();
            _controller = new CdbInvestmentController(_mockCdbInvestmentService.Object);
        }

        [TestMethod]
        public void Post_ValidInvestment_ReturnsOk()
        {
            // Arrange
            var validInvestment = new Investment { Amount = 500, Months = 2 };
            var expectedResponse = new InvestmentResponse { GrossAmount = 509.77m, NetAmount = 507.57m };

            _mockCdbInvestmentService
                .Setup(service => service.CalculateInvestment(validInvestment))
                .Returns(expectedResponse);

            // Act
            IHttpActionResult result = _controller.Post(validInvestment);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<InvestmentResponse>));
            var contentResult = (OkNegotiatedContentResult<InvestmentResponse>)result;
            Assert.AreEqual(expectedResponse, contentResult.Content);
        }

        [TestMethod]
        public void Post_InvalidInvestment_ReturnsBadRequest()
        {
            // Arrange
            var invalidInvestment = new Investment { };

            // Act
            IHttpActionResult result = _controller.Post(invalidInvestment);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            var contentResult = (NegotiatedContentResult<string>)result;
            Assert.AreEqual(HttpStatusCode.BadRequest, contentResult.StatusCode);
        }
    }
}
