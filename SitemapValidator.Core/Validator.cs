using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace SitemapValidator.Core
{
    public class Validator
    {
        private readonly HttpClient _httpClient;
        private readonly IProgressUpdater _progressUpdater;

        public Validator(HttpClient httpClient, IProgressUpdater progressUpdater)
        {
            _httpClient = httpClient;
            _progressUpdater = progressUpdater;
        }

        public List<ValidationResult> Validate(Sitemap sitemap, Options options)
        {
            var results = new List<ValidationResult>();

            for (var i = 0; i < sitemap.Urls.Count; i++)
            {
                _progressUpdater.UpdateStatusText($"Validating {i + 1}/{sitemap.Urls.Count}");

                var result = ValidateUrl(sitemap.Urls[i], options.Delay, options.ExpectedStatusCode);
                results.Add(result);

                _progressUpdater.Log(result, options.Verbose);
            }

            return results;
        }

        private ValidationResult ValidateUrl(string url, int delay, int expectedStatusCode)
        {
            DelayRequest(delay);

            return ValidateUrl(expectedStatusCode, url);
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
