using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Kurukuru;
using SitemapValidator.Core;

namespace SitemapValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            Console.OutputEncoding = Encoding.UTF8;

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var httpClient = GetHttpClient();

                Spinner.Start("Validating Sitemap ", (spinner) => Validate(spinner, httpClient, options));

                return;
            }

            Console.WriteLine("Failed to parse arguments, sitemapvalidator.exe -u example.com/sitemap.xml -c 200 -v");
        }

        static void Validate(Spinner spinner, HttpClient httpClient, Options options)
        {
            var progressUpdater = new SpinnerProgressUpdater(spinner);

            var sitemap = new SitemapRetriever(httpClient).Retrieve(options.Url);

            var validationResults = new Validator(httpClient, progressUpdater).Validate(sitemap, options);

            spinner.Stop();

            var groupedByStatusCode = validationResults
                .OrderBy(x => x.ActualHttpStatusCode)
                .GroupBy(x => x.ActualHttpStatusCode);

            Console.WriteLine("\nFound Status Codes: ");

            foreach (var statusCodeGroup in groupedByStatusCode)
            {
                Console.WriteLine($"\t{statusCodeGroup.Key}: {statusCodeGroup.Count()}");
            }

            if (string.IsNullOrEmpty(options.ExportFilename)) return;

            //using (var textWriter = File.CreateText(options.ExportFilename))
            //{
            //    new SitemapExporter(textWriter).Export(validationResults);
            //}
        }

        static HttpClient GetHttpClient()
        {
            // Some backend servers use UA and can fail if it is not present
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent",
                @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; 
            WOW64; Trident / 6.0)");

            return httpClient;
        }
    }
}
