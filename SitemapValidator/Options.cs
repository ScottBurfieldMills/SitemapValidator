using CommandLine;

namespace SitemapValidator
{
    public class Options : Core.Options
    {
        [Option('s', "sitemap", Required = true, HelpText = "Sitemap URL")]
        public override string Url { get; set; }

        [Option('c', "code", DefaultValue = 200, HelpText = "Expected Status Code")]
        public override int ExpectedStatusCode { get; set; }

        [Option('v', "verbose", DefaultValue = false, HelpText = "Enable Verbose Output")]
        public override bool Verbose { get; set; }

        [Option('d', "d", DefaultValue = 500, HelpText = "Delay between each request")]
        public override int Delay { get; set; }

        [Option('e', "e", DefaultValue = "", HelpText = "Export filename")]
        public override string ExportFilename { get; set; }
    }
}