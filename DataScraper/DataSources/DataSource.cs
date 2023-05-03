namespace DataScraper.DataSources
{
    public abstract class DataSource : IDataSource
    {
        protected abstract bool IsValidSource();
    }
}
