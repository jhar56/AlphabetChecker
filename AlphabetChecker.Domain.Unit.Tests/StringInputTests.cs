using AlphabetChecker.Domain.Models;

namespace AlphabetChecker.Domain.Unit.Tests
{
    [TestClass]
    public class StringInputTests
    {
        [TestMethod]
        public void StringInput_CreatesInstance()
        {
            // Arrange & Act
            var input = new StringInput { Input = "Test" };

            // Assert
            Assert.AreEqual("Test", input.Input);
        }
    }
}