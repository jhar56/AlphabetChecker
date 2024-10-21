using AlphabetChecker.API.Controllers;
using AlphabetChecker.Domain.Models;
using AlphabetChecker.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AlphabetChecker.API.Unit.Tests
{
    [TestClass]
    public class AlphabetControllerTests
    {
        private Mock<IAlphabetCheckerService> _mockService;
        private AlphabetController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockService = new Mock<IAlphabetCheckerService>();
            _controller = new AlphabetController(_mockService.Object);
        }

        [TestMethod]
        public void CheckAlphabet_InputContainsAllLetters_ReturnsOkResult()
        {
            // Arrange
            StringInput input = new StringInput();
            input.Input = "The quick brown fox jumps over the lazy dog";
            _mockService.Setup(s => s.ContainsAllLetters(input.Input)).Returns(true);

            // Act
            var result = _controller.CheckString(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(true, result.Value);
        }

        [TestMethod]
        public void CheckAlphabet_InputDoesNotContainAllLetters_ReturnsOkResultWithFalse()
        {
            // Arrange
            StringInput input = new StringInput();
            input.Input = "Hello World";
            _mockService.Setup(s => s.ContainsAllLetters(input.Input)).Returns(false);

            // Act
            var result = _controller.CheckString(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(false, result.Value);
        }

        [TestMethod]
        public void CheckAlphabet_InputIsNull_ReturnsBadRequest()
        {
            // Act
            var result = _controller.CheckString(null) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Input cannot be null", result.Value);
        }
    }
}