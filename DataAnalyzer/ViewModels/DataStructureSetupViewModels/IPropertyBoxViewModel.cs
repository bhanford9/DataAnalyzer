using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IPropertyBoxViewModel
    {
        string ContainerName { get; set; }
        ICollection<IStringPropertyRowViewModel> Properties { get; set; }
    }
}