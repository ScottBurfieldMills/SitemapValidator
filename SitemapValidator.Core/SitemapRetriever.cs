using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace SitemapValidator.Core
{
    public class SitemapRetriever
    {
        private readonly HttpClient _httpClient;

        public SitemapRetriever(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Sitemap Retrieve(string url)
        {
            var document = new XmlDocument();
            document.LoadXml(GetSitemapContents(url));

            var urls = GetUrls(document);

            return new Sitemap(urls);
        }

        private string GetSitemapContents(string url)
        {
            var response = _httpClient.GetAsync(url)
                .Result;

            var content = response.Content.ReadAsStringAsync().Result;

            return content;
        }

        private List<string> GetUrls(XmlDocument document)
        {
            var urls = new List<string>();

            var urlSetUrls = document.GetElementsByTagName(Sitemap.Tags.Url);

            foreach (XmlNode parentNode in urlSetUrls)
            {
                foreach (XmlNode childNode in parentNode.ChildNodes)
                {
                    if (childNode.Name != Sitemap.Tags.Loc || string.IsNullOrEmpty(childNode.InnerText)) continue;

                    urls.Add(childNode.InnerText);
                }
            }

            return urls;
        }
    }
}
