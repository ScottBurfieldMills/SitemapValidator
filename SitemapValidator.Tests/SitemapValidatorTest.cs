using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace SitemapValidator.Tests
{
    [TestFixture]
    public class SitemapValidatorTest
    {
        [Test]
        public void Test()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://scottbm.me")
                .Respond(HttpStatusCode.OK, "text/html", "");

            var httpClient = new HttpClient(mockHttp);

            var validator = new SitemapValidator(httpClient);

            var sitemap = new Sitemap(new List<string> { "http://scottbm.me/" });

            var results = validator.Validate(sitemap, new Options { ExpectedStatusCode = 200 });

            Assert.IsTrue(results.First().Verify());
        }
    }
}
