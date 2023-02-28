using DataScraper.Data;
using DataScraper.Data.CsvData;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.IO;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    internal class CsvNamesScraper : IDataScraper
    {
        public string Name => "CSV Names Scraper";

        public ICollection<IData> ScrapeFromSource(IDataSource source)
        {
            string filePath = (source as FileDataSource).FilePath;

            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrEmpty(line)) continue;
                return new List<IData> { new CsvNamesData { CsvNames = line.Split(',') } };
            }

            return new List<IData>();
        }
    }
}
