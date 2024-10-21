using Microsoft.Extensions.Logging;
using Moq;

namespace AlphabetChecker.Service.Unit.Tests
{
    [TestClass]
    public class AlphabetCheckerServiceTests
    {
        private Mock<ILogger<AlphabetCheckerService>> _mockLogger;
        private AlphabetCheckerService _service;

        [TestInitialize]
        public void Initialize()
        {
            _mockLogger = new Mock<ILogger<AlphabetCheckerService>>();
            _service = new AlphabetCheckerService(_mockLogger.Object);
        }

        [TestMethod]
        public void ContainsAllLetters_InputContainsAllLetters_ReturnsTrue()
        {
            // Arrange
            var input = "The quick brown fox jumps over the lazy dog";

            // Act
            var result = _service.ContainsAllLetters(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsAllLetters_InputDoesNotContainAllLetters_ReturnsFalse()
        {
            // Arrange
            var input = "Hello World";

            // Act
            var result = _service.ContainsAllLetters(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsAllLetters_InputIsNullOrEmpty_ReturnsFalse()
        {
            // Arrange
            string input = null;

            // Act
            var result = _service.ContainsAllLetters(input);

            // Assert
            Assert.IsFalse(result);

            // Verify that a warning log was called
            _mockLogger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
                ),
                Times.Once);
        }
    }
}