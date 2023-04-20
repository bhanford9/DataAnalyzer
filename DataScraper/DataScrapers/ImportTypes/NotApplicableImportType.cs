namespace DataScraper.DataScrapers.ImportTypes
{
    public interface INotApplicableImportType : IImportType { }
    public class NotApplicableImportType : ImportType<HttpImportType>, INotApplicableImportType
    {
        public override string Name => "Not Applicable";
    }
}
