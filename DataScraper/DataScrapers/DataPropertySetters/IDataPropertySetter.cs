using DataScraper.Data;

namespace DataScraper.DataScrapers.DataPropertySetters;

public interface IDataPropertySetter
{
    void Set(IData data, string value);
}