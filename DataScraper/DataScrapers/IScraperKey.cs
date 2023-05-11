namespace DataScraper.DataScrapers;

public interface IScraperKey
{
    string Name { get; }

    bool Equals(object obj);
    int GetHashCode();
    string ToString();
}