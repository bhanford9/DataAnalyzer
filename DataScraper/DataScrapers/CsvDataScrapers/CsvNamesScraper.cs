using DataScraper.Data;
using DataScraper.Data.CsvData;
using System.Collections.Generic;
using System.IO;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    internal class CsvNamesScraper : IDataScraper
    {
        public ScraperType ScraperType => ScraperType.CsvNames;

        public ICollection<IData> ScrapeFromFile(string filePath)
        {
            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrEmpty(line)) continue;
                return new List<IData> { new CsvNamesData { CsvNames = line.Split(',') } };
            }

            return new List<IData>();
        }
    }
}
