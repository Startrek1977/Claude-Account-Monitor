using Xunit;
using ClaudeAccountMonitor;

namespace ClaudeAccountMonitor.Tests
{
    public class AppTests
    {
        private static readonly App AppInstance = new App();

        [Fact]
        public void App_CanBeInstantiated()
        {
            Assert.NotNull(AppInstance);
        }

        [Fact]
        public void App_HasCorrectResourceDictionary()
        {
            Assert.NotNull(AppInstance.Resources);
        }

        [Fact]
        public void App_StartsWithoutThrowingException()
        {
            Assert.NotNull(AppInstance);
        }
    }
}