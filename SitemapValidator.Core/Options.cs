namespace SitemapValidator.Core
{
    public class Options
    {
        public virtual string Url { get; set; }

        public virtual int ExpectedStatusCode { get; set; }

        public virtual bool Verbose { get; set; }

        public virtual int Delay { get; set; }

        public virtual string ExportFilename { get; set; }
    }
}
