namespace SitemapValidator.Core
{
    public interface IProgressUpdater
    {
        void UpdateStatusText(string message, bool verbose = false);

        void Log(ValidationResult result, bool verbose = false);
    }
}
