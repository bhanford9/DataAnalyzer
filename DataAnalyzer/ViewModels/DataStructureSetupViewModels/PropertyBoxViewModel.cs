using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels;

internal class PropertyBoxViewModel : BasePropertyChanged, IPropertyBoxViewModel
{
    private string containerName = string.Empty;
    private ICollection<IStringPropertyRowViewModel> properties =
        new List<IStringPropertyRowViewModel>();

    public string ContainerName
    {
        get => this.containerName;
        set => this.NotifyPropertyChanged(ref this.containerName, value);
    }

    public ICollection<IStringPropertyRowViewModel> Properties
    {
        get => this.properties;
        set => this.NotifyPropertyChanged(ref this.properties, value);
    }
}
