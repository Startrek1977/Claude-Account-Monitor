using Xunit;
using Claude_Account_Monitor;

namespace Claude_Account_Monitor.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void MainWindow_CanBeInstantiated()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window);
        }

        [Fact]
        public void MainWindow_HasCorrectTitle()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window.Title);
        }

        [Fact]
        public void MainWindow_HasContent()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window.Content);
        }

        [Fact]
        public void MainWindow_HasValidDimensions()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.True(window.Width > 0);
            Assert.True(window.Height > 0);
        }
    }
}
