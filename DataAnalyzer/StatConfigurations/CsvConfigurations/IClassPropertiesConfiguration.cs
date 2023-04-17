using System.Collections.Generic;

namespace DataAnalyzer.StatConfigurations.CsvConfigurations
{
    internal interface IClassPropertiesConfiguration : IDataConfiguration
    {
        List<string> PropertyNames { get; set; }
    }
}