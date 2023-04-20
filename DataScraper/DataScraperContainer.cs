using Autofac;
using DataScraper.Data;
using DataScraper.Data.CsvData;
using DataScraper.Data.TimeData;
using DataScraper.Data.TimeData.QueryableData;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.CsvDataScrapers;
using DataScraper.DataScrapers.DataPropertySetters;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.TimeDataScrapers;
using DataScraper.DataSources;
using DependencyInjectionUtilities;

namespace DataScraper
{
    public class DataScraperContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // DataScraper.Data.CsvData
            builder.RegisterType<ICsvNamesData, CsvNamesData>();
            builder.RegisterType<ICsvTestData, CsvTestData>();

            // DataScraper.Data.TimeData.QueryableData
            builder.RegisterType<IQueryableTimeData, QueryableTimeData>();

            // DataScraper.Data.TimeData
            builder.RegisterType<ITimeData, TimeData>();

            // DataScraper.DataScrapers.CsvDataScrapers
            builder.RegisterTypeAncestors<IDataScraper, ICsvNamesScraper, CsvNamesScraper>();
            builder.RegisterTypeAncestors<IDataScraper, ICsvIndexedScraper, ICsvTestScraper, CsvTestScraper>();

            // DataScraper.DataScrapers.DataPropertySetters
            builder.RegisterTypeAncestors<IDataPropertySetter, IDataBoolPropertySetter, DataBoolPropertySetter<IData>>();
            builder.RegisterTypeAncestors<IDataPropertySetter, IDataDateTimePropertySetter, DataDateTimePropertySetter<IData>>();
            builder.RegisterTypeAncestors<IDataPropertySetter, IDataDoublePropertySetter, DataDoublePropertySetter<IData>>();
            builder.RegisterTypeAncestors<IDataPropertySetter, IDataIntPropertySetter, DataIntPropertySetter<IData>>();
            builder.RegisterTypeAncestors<IDataPropertySetter, IDataStringPropertySetter, DataStringPropertySetter<IData>>();

            // DataScraper.DataScrapers.ImportTypes
            builder.RegisterTypeAncestors<IScraperKey, IImportType, IDatabaseImportType, DatabaseImportType>();
            builder.RegisterTypeAncestors<IScraperKey, IImportType, IFileImportType, FileImportType>();
            builder.RegisterTypeAncestors<IScraperKey, IImportType, IHttpImportType, HttpImportType>();
            builder.RegisterTypeAncestors<IScraperKey, IImportType, INotApplicableImportType, NotApplicableImportType>();

            // DataScraper.DataScrapers.ScraperCategories
            builder.RegisterTypeAncestors<IScraperKey, IScraperCategory, ICsvNamesScraperCategory, CsvNamesScraperCategory>();
            builder.RegisterTypeAncestors<IScraperKey, IScraperCategory, ICsvScraperCategory, CsvScraperCategory>();
            builder.RegisterTypeAncestors<IScraperKey, IScraperCategory, IQueryableScraperCategory, QueryableScraperCategory>();
            builder.RegisterTypeAncestors<IScraperKey, IScraperCategory, INotApplicableScraperCategory, NotApplicableScraperCategory>();

            // DataScraper.DataScrapers.ScraperFlavors.CsvFlavors
            builder.RegisterTypeAncestors<IScraperKey, IScraperFlavor, ICsvTestScraperFlavor, CsvTestScraperFlavor>();

            // DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors
            builder.RegisterTypeAncestors<IScraperKey, IScraperFlavor, ICsvNamesStandardScraperFlavor, CsvNamesStandardScraperFlavor>();
            
            // DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors
            builder.RegisterTypeAncestors<IScraperKey, IScraperFlavor, IQueryableStandardScraperFlavor, QueryableStandardScraperFlavor>();
            
            // DataScraper.DataScrapers.ScraperFlavors
            builder.RegisterTypeAncestors<IScraperKey, IScraperFlavor, INotApplicableScraperFlavor, NotApplicableScraperFlavor>();

            // DataScraper.DataScrapers.TimeDataScrapers
            builder.RegisterTypeAncestors<IDataScraper, IQueryableDataScraper, QueryableDataScraper>();

            // DataScraper.DataScrapers
            builder.RegisterTypeInstance<IScraperLibrary, ScraperLibrary>();

            // DataScraper.DataSources
            builder.RegisterTypeAncestors<IDataSource, IFileDataSource, FileDataSource>();

            // DataScraper
            builder.RegisterTypeInstance<IScraperExecutive, ScraperExecutive>();
        }
    }
}