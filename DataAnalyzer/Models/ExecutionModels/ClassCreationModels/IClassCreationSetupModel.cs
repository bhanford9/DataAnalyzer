using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels
{
    internal interface IClassCreationSetupModel : INotifyPropertyChanged
    {
        IClassCreationConfigurationModel ClassCreationConfigModel { get; }
        string ConfigurationName { get; set; }
        ObservableCollection<IPropertyData> DataItems { get; }

        string GetClassString(string className, ICollection<IPropertyData> propertyData);
        void LoadDataFromConfiguration();
    }
}