using System.Collections.Generic;
using System.IO;
using NSubstitute;
using NUnit.Framework;

namespace SitemapValidator.Tests
{
    [TestFixture]
    public class SitemapExporterTest
    {
        [Test]
        public void Test()
        {
            var textWriter = Substitute.For<TextWriter>();

            var exporter = new SitemapExporter(textWriter);

            //var validationResults = new List<ValidationResult>();

            //exporter.Export(validationResults);

            //Assert.IsTrue(true);
        }
    }
}
