namespace DataScraper.Data.CsvData
{
    public interface ICsvTestData : IData
    {
        int Age { get; set; }
        DateTime Date { get; set; }
        string Gender { get; set; }
        string Name { get; set; }
    }
}