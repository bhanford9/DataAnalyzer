using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataScraper
{
    public interface IFlavoredCategorizedDataLibrary<T> : IDictionary<IImportType, IDictionary<IScraperCategory, IDictionary<IScraperFlavor, T>>>
    {
        T this[IImportType type, IScraperCategory category, IScraperFlavor flavor] { get; }

        string Name { get; }

        void FromSerializable(List<KeyValuePair<IImportType, List<KeyValuePair<IScraperCategory, List<KeyValuePair<IScraperFlavor, T>>>>>> source);
        IReadOnlyCollection<IScraperCategory> GetCategories(IImportType type, bool appendNotApplicable = false);
        IReadOnlyCollection<string> GetCategoryNames(IImportType type, bool appendNotApplicable = false);
        T GetData(IImportType type, IScraperCategory category, IScraperFlavor flavor);
        IReadOnlyCollection<string> GetFlavorNames(IImportType type, IScraperCategory category, bool appendNotApplicable = false);
        IReadOnlyCollection<IScraperFlavor> GetFlavors(IImportType type, IScraperCategory category, bool appendNotApplicable = false);
        IReadOnlyCollection<string> GetImportTypeNames();
        IReadOnlyCollection<IImportType> GetImportTypes();
        List<KeyValuePair<IImportType, List<KeyValuePair<IScraperCategory, List<KeyValuePair<IScraperFlavor, T>>>>>> ToSerializable();
        bool TryGetData(IImportType type, IScraperCategory category, IScraperFlavor flavor, out T data);
    }
}