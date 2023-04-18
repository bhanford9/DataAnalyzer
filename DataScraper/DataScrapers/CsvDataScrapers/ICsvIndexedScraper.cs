using DataScraper.DataScrapers.DataPropertySetters;
using System.Collections.Generic;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    public interface ICsvIndexedScraper : IDataScraper
    {
        List<IDataPropertySetter> DataSetters { get; }
    }
}