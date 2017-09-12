using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SitemapValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var httpClient = GetHttpClient();

                var sitemap = new SitemapRetriever(httpClient).Retrieve(options.Url);

                new SitemapValidator(httpClient).Validate(sitemap, options);

                Console.WriteLine("Finished");
                Console.ReadLine();

                return;
            }

            Console.WriteLine("Failed to parse arguments, sitemapvalidator.exe -u example.com/sitemap.xml -c 200 -v");
            Console.ReadLine();
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
