using System;

namespace SitemapValidator
{
    public static class SitemapLogger
    {
        public static void Log(ValidationResult result, bool verbose)
        {
            if (result.Verify() && !verbose) return;

            var message = result.Verify()
                ? $"{result.Url} Matched Status Code {result.ExpectedHttpStatusCode}"
                : $"{result.Url} Expected Status Code {result.ExpectedHttpStatusCode} but received {result.ActualHttpStatusCode}";

            Console.WriteLine(message);

            Console.Out.Flush();
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}