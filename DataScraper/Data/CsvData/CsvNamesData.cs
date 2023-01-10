using System.Collections.Generic;

namespace DataScraper.Data.CsvData
{
    public class CsvNamesData : IData
    {
        public ICollection<string> CsvNames { get; set; } = new List<string>();
    }
}
