using System.Net.Http;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace SitemapValidator.Tests
{
    [TestFixture]
    public class SitemapRetrieverTest
    {
        [Test]
        public void Test()
        {
            var httpClient = GetMockHttpClient("http://scottbm.me/sitemap.xml",
                @"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">
<url>
<loc>http://scottbm.me/</loc>
<lastmod>2017-09-01</lastmod>
<changefreq>weekly</changefreq>
<priority>0.5</priority>
</url></urlset>");

            var retriever = new SitemapRetriever(httpClient);

            var sitemap = retriever.Retrieve("http://scottbm.me/sitemap.xml");

            Assert.AreEqual(1, sitemap.Urls.Count);
        }

        private HttpClient GetMockHttpClient(string url, string response)
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When(url)
                .Respond("text/xml", response);

            return new HttpClient(mockHttp);
        }
    }
}
