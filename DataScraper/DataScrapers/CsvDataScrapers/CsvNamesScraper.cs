using DataScraper.Data;
using DataScraper.Data.CsvData;
using DataScraper.DataSources;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    public class CsvNamesScraper : ICsvNamesScraper
    {
        public string Name => "CSV Names Scraper";

        public bool IsValidSource(IDataSource source)
        {
            return source is FileDataSource s && File.Exists(s.FilePath);
        }

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
