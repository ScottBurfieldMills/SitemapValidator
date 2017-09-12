using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace SitemapValidator
{
    public class SitemapValidator
    {
        private readonly HttpClient _httpClient;

        public SitemapValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ValidationResult> Validate(Sitemap sitemap, Options options)
        {
            SitemapLogger.Log("Validating " + sitemap.Urls.Count + " urls");

            var results = new List<ValidationResult>();

            foreach (var url in sitemap.Urls)
            {
                DelayRequest(options.Delay);

                var result = ValidateUrl(options.ExpectedStatusCode, url);

                SitemapLogger.Log(result, options.Verbose);

                results.Add(result);
            }

            return results;
        }

        private ValidationResult ValidateUrl(int expectedStatusCode, string url)
        {
            var response = _httpClient.GetAsync(url).Result;

            return new ValidationResult(url, expectedStatusCode, (int)response.StatusCode);
        }

        private static void DelayRequest(int delay)
        {
            Thread.Sleep(delay);
        }
    }
}