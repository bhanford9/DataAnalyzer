using DataScraper.Data.CsvData;
using DataScraper.DataScrapers.DataPropertySetters;
using System.Collections.Generic;

namespace DataScraper.DataScrapers.CsvDataScrapers;

// TODO --> make this a generic CSV scraper such that children only need to map column number to property
public class CsvTestScraper : CsvIndexedScraper<CsvTestData>, ICsvTestScraper
{
    public CsvTestScraper() : base(() => new CsvTestData()) { }

    public override string Name => "Test CSV Scraper";

    public override List<IDataPropertySetter> DataSetters => new()
    {
        new DataDateTimePropertySetter<CsvTestData>((result, data) => result.Date = data),
        new DataStringPropertySetter<CsvTestData>((result, data) => result.Name = data),
        new DataIntPropertySetter<CsvTestData>((result, data) => result.Age = data),
        new DataStringPropertySetter<CsvTestData>((result, data) => result.Gender = data),
    };
}
