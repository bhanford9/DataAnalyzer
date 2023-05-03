using System.Collections.Generic;

namespace DataAnalyzer.StatConfigurations.CsvConfigurations
{
    internal interface IClassPropertiesConfiguration : IDataConfiguration
    {
        string ClassName { get; set; }

        List<string> PropertyNames { get; set; }
    }
}