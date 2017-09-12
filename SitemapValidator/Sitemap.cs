using System.Collections.Generic;

namespace SitemapValidator
{
    public class Sitemap
    {
        public static class Tags
        {
            public static string Url = "url";
            public static string Loc = "loc";
        }

        public List<string> Urls { get; }

        public Sitemap(List<string> urls)
        {
            Urls = urls;
        }
    }
}