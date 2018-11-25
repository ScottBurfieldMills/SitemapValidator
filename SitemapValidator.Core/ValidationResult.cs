namespace SitemapValidator.Core
{
    public class ValidationResult
    {
        public string Url { get; set; }
        public int ExpectedHttpStatusCode { get; set; }
        public int ActualHttpStatusCode { get; set; }

        public ValidationResult(string url, int expectedHttpStatusCode, int actualHttpStatusCode)
        {
            Url = url;
            ExpectedHttpStatusCode = expectedHttpStatusCode;
            ActualHttpStatusCode = actualHttpStatusCode;
        }

        public bool Verify()
        {
            return ExpectedHttpStatusCode == ActualHttpStatusCode;
        }
    }
}
