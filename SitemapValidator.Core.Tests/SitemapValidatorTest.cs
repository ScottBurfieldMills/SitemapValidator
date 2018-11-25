using Moq;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SitemapValidator.Core.Tests
{
    public class SitemapValidatorTest
    {
        [Fact]
        public void Test()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://scottbm.me")
                    .Respond(HttpStatusCode.OK, "text/html", "");

            var httpClient = new HttpClient(mockHttp);

            var mockProgressUpdater = new Mock<IProgressUpdater>();

            var validator = new Validator(httpClient, mockProgressUpdater.Object);

            var sitemap = new Sitemap(new List<string> { "http://scottbm.me/" });

            var results = validator.Validate(sitemap, new Options { ExpectedStatusCode = 200 });

            Assert.True(results.First().Verify());
        }
    }
}
