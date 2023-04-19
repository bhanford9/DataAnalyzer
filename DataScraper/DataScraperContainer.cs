using Autofac;
using DataScraper.Data;
using DataScraper.Data.CsvData;
using DataScraper.Data.TimeData;
using DataScraper.Data.TimeData.QueryableData;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.CsvDataScrapers;
using DataScraper.DataScrapers.DataPropertySetters;
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
            // DataScraper.DataScrapers.ScraperCategories
            // DataScraper.DataScrapers.ScraperFlavors.CsvFlavors
            // DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors
            // DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors
            // DataScraper.DataScrapers.ScraperFlavors
            // DataScraper.DataScrapers.TimeDataScrapers
            // DataScraper.DataScrapers
            // DataScraper.DataSources
            // DataScraper
        }
    }
}