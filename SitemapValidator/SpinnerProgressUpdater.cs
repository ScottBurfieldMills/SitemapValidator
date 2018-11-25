using System;
using Kurukuru;
using SitemapValidator.Core;

namespace SitemapValidator
{
    public class SpinnerProgressUpdater : IProgressUpdater
    {
        private readonly Spinner _spinner;

        public SpinnerProgressUpdater(Spinner spinner)
        {
            _spinner = spinner;
        }

        public void UpdateStatusText(string message, bool verbose = false)
        {
            _spinner.Text = message;
        }

        void IProgressUpdater.Log(Core.ValidationResult result, bool verbose)
        {
            if (result.Verify() && !verbose) return;

            var message = result.Verify()
                ? $"\n{result.Url} Matched Status Code {result.ExpectedHttpStatusCode}"
                : $"\n{result.Url} Expected Status Code {result.ExpectedHttpStatusCode} but received {result.ActualHttpStatusCode}";

            Console.WriteLine(message);
        }
    }
}
