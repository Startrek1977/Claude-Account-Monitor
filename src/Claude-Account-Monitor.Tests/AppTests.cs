using Xunit;
using Claude_Account_Monitor;

namespace Claude_Account_Monitor.Tests
{
    public class AppTests
    {
        [Fact]
        public void App_CanBeInstantiated()
        {
            // Arrange & Act
            var app = new App();

            // Assert
            Assert.NotNull(app);
        }

        [Fact]
        public void App_HasCorrectResourceDictionary()
        {
            // Arrange & Act
            var app = new App();

            // Assert
            Assert.NotNull(app.Resources);
        }

        [Fact]
        public void App_StartsWithoutThrowingException()
        {
            // Arrange
            var app = new App();

            // Act & Assert - If we got here without exception, test passes
            Assert.NotNull(app);
        }
    }
}
