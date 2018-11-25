using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using SitemapValidator.Core;

namespace SitemapValidator
{
    public class SitemapExporter
    {
        private readonly TextWriter _textWriter;

        public SitemapExporter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Export(List<ValidationResult> results)
        {
            var writer = new CsvWriter(_textWriter);

            writer.WriteHeader<ValidationResult>();

            writer.WriteRecords(results);
        }
    }
}
