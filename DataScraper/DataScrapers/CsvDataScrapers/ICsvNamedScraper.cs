using DataScraper.DataScrapers.DataPropertySetters;
using System.Collections.Generic;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    public interface ICsvNamedScraper : IDataScraper
    {
        Dictionary<string, IDataPropertySetter> DataSetters { get; }
    }
}