using System.Collections.Generic;

namespace DataScraper.Data.CsvData
{
    public class CsvNamesData : ICsvNamesData
    {
        public ICollection<string> CsvNames { get; set; } = new List<string>();
    }
}
