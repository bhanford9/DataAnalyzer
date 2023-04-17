using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal class DataStructureSetupViewModelRepository : ImportExportDataRepository<IDataStructureSetupViewModel>, IDataStructureSetupViewModelRepository
    {
        public DataStructureSetupViewModelRepository()
        {
            // TODO --> instantiate internal collections with relevant view models
        }

        public void Initialize()
        {
            // TODO --> should probably use the resolver instead for all these new's

            FileImportType fileType = new();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDictionary<ExportType, IDataStructureSetupViewModel>>>();

            this.InitializeCategory(fileType, new QueryableScraperCategory())
                .WithFlavoredData(
                    new QueryableStandardScraperFlavor(),
                    ExportType.Excel,
                    Resolver.Resolve<IGroupingSetupViewModel>());

            this.InitializeCategory(fileType, new CsvNamesScraperCategory())
                .WithFlavoredData(
                    new CsvNamesStandardScraperFlavor(),
                    ExportType.CSharpStringProperties,
                    Resolver.Resolve<ICsvCSharpStringClassSetupViewModel>())
                .WithFlavoredData(
                    new CsvTestScraperFlavor(),
                    ExportType.CSharpStringProperties,
                    Resolver.Resolve<ICsvCSharpStringClassSetupViewModel>());
        }

        public override string Name => "DataStructureSetupViewModelRepository";
    }
}
