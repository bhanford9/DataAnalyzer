using System.Collections.Generic;
using DataScraper.DataScrapers.CsvDataScrapers;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.TimeDataScrapers;
using DependencyInjectionUtilities;
using DataScraper.DataScrapers.ScraperFlavors.JsonFlavors;
using DataScraper.DataScrapers.JsonDataScrapers;

namespace DataScraper.DataScrapers;

public class ScraperLibrary : FlavoredCategorizedDataLibrary<IDataScraper>, IScraperLibrary
{
    public ScraperLibrary()
    {
        IFileImportType fileType = Get<IFileImportType>();
        //DatabaseImportType databaseType = new DatabaseImportType();
        //HttpImportType httpType = new HttpImportType();

        this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDataScraper>>();
        
        this.InitializeCategory(fileType, Get<IQueryableScraperCategory>())
            .AddFlavoredData(Get<IQueryableStandardScraperFlavor>(), Get<IQueryableDataScraper>());
        
        this.InitializeCategory(fileType, Get<ICsvNamesScraperCategory>())
            .AddFlavoredData(Get<ICsvNamesStandardScraperFlavor>(), Get<ICsvNamesScraper>());
        
        this.InitializeCategory(fileType, Get<ICsvScraperCategory>())
            .AddFlavoredData(Get<ICsvTestScraperFlavor>(), Get<ICsvTestScraper>());
        
        this.InitializeCategory(fileType, Get<IJsonObjectScraperCategory>())
            .AddFlavoredData(Get<IJsonGeneralObjectScraperFlavor>(), Get<IGeneralJsonObjectScraper>());
    }

    public override string Name => "Scraper";

    private static T Get<T>() => Resolver.Resolve<T>();
}
