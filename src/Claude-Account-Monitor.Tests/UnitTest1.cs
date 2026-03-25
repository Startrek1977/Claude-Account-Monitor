using Xunit;
using Xunit.Sdk;
using ClaudeAccountMonitor;

namespace ClaudeAccountMonitor.Tests
{
    public class MainWindowTests
    {
        [StaFact]
        public void MainWindow_CanBeInstantiated()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window);
        }

        [StaFact]
        public void MainWindow_HasCorrectTitle()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window.Title);
        }

        [StaFact]
        public void MainWindow_HasContent()
        {
            // Arrange & Act
            var window = new MainWindow();

            // Assert
            Assert.NotNull(window.Content);
        }

        [StaFact]
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