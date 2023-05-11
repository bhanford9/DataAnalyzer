using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations;

internal interface ICsvNamesDataConfiguration : IDataConfiguration
{
    string ClassName { get; set; }
    ICollection<(string CsvName, string PropertyName, bool Include)> CsvNameAndProperties { get; set; }
}