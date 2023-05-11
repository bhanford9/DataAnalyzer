using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using DataAnalyzer.Services.Enums;
using System.Linq;
using DataAnalyzer.Services.ExecutiveUtilities.Executives;
using DataScraper.DataScrapers.ScraperFlavors.JsonFlavors;

namespace DataAnalyzer.Services.ExecutiveUtilities;

// TODO --> register as singleton
internal class ExecutiveUtilitiesRepository :
    ImportExecutionDataRepository<IAggregateExecutives>,
    IExecutiveUtilitiesRepository
{
    public ExecutiveUtilitiesRepository()
    {
    }

    public void Initialize()
    {
        FileImportType fileType = new();
        //DatabaseImportType databaseType = new DatabaseImportType();
        //HttpImportType httpType = new HttpImportType();

        this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDictionary<ExecutionType, IAggregateExecutives>>>();

        this.InitializeCategory(fileType, new QueryableScraperCategory())
            .WithFlavoredData(new QueryableStandardScraperFlavor(), ExecutionType.Excel, new QueryableExcelCreation());

        this.InitializeCategory(fileType, new CsvNamesScraperCategory())
            .WithFlavoredData(new CsvNamesStandardScraperFlavor(), ExecutionType.CSharpStringProperties, new CsvCSharpClassCreation())
            .WithFlavoredData(new CsvNamesStandardScraperFlavor(), ExecutionType.CSharpStringProperties, new CsvTest());

        this.InitializeCategory(fileType, new JsonObjectScraperCategory())
            .WithFlavoredData(new JsonGeneralObjectScraperFlavor(), ExecutionType.CSharpStringProperties, new CSharpClassCreation());
    }

    public override string Name => "Executive Utilities";

    public IReadOnlyCollection<ExecutionType> GetExecutionTypes(IImportType import, IScraperCategory category, IScraperFlavor flavor)
        => this[import][category][flavor].Keys.ToList();

    public IReadOnlyCollection<string> GetExecutionTypeNamess(IImportType import, IScraperCategory category, IScraperFlavor flavor)
        => GetExecutionTypes(import, category, flavor).Select(x => x.ToString()).ToList();

    //public IEnumerable<IDataStructureSetupViewModel> StructureSetupViewModels => this.GetAll(x => x.DataStructureSetupViewModel);
}
