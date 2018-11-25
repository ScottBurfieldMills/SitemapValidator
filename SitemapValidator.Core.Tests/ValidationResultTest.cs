using Xunit;

namespace SitemapValidator.Core.Tests
{
    public class ValidationResultTest
    {
        [Fact]
        public void ShouldVerifyIfStatusCodeIsSame()
        {
            var result = new ValidationResult("http://scottbm.me", 200, 200);

            Assert.True(result.Verify());
        }

        [Fact]
        public void ShouldVerifyIfStatusCodeIsDifferent()
        {
            var result = new ValidationResult("http://scottbm.me", 200, 503);

            Assert.False(result.Verify());
        }
    }
}
