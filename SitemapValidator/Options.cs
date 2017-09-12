using CommandLine;

namespace SitemapValidator
{
    public class Options
    {
        [Option('s', "sitemap", Required = true, HelpText = "Sitemap URL")]
        public string Url { get; set; }

        [Option('c', "code", DefaultValue = 200, HelpText = "Expected Status Code")]
        public int ExpectedStatusCode { get; set; }

        [Option('v', "verbose", DefaultValue = false, HelpText = "Enable Verbose Output")]
        public bool Verbose { get; set; }

        [Option('d', "d", DefaultValue = 500, HelpText = "Delay between each request")]
        public int Delay { get; set; }
    }
}