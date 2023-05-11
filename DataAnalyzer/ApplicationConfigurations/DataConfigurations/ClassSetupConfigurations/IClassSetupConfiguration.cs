using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal interface IClassSetupConfiguration
{
    string Accessibility { get; set; }
    string ClassName { get; set; }
    ICollection<IPropertySetupConfiguration> Properties { get; set; }
}