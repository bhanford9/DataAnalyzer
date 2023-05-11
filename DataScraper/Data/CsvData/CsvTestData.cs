using System;

namespace DataScraper.Data.CsvData;

public class CsvTestData : ICsvTestData
{
    public DateTime Date { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Gender { get; set; } = string.Empty;
}
