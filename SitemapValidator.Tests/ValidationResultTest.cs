using NUnit.Framework;

namespace SitemapValidator.Tests
{
    [TestFixture]
    public class ValidationResultTest
    {
        [Test]
        public void ShouldVerifyIfStatusCodeIsSame()
        {
            var result = new ValidationResult("http://scottbm.me", 200, 200);
            
            Assert.IsTrue(result.Verify());
        }

        [Test]
        public void ShouldVerifyIfStatusCodeIsDifferent()
        {
            var result = new ValidationResult("http://scottbm.me", 200, 503);

            Assert.IsFalse(result.Verify());
        }
    }
}
