namespace DataScraper.Data.CsvData
{
    public interface ICsvNamesData : IData
    {
        ICollection<string> CsvNames { get; set; }
    }
}