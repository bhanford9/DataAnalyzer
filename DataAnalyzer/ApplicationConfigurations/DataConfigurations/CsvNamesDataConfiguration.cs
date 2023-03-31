using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class CsvNamesDataConfiguration : DataConfiguration, ICsvNamesDataConfiguration
    {
        public string ClassName { get; set; }

        public ICollection<(string CsvName, string PropertyName, bool Include)> CsvNameAndProperties { get; set; }
            = new List<(string CsvName, string PropertyName, bool Include)>();
    }
}
