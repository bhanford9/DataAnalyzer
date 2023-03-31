using DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
    internal interface IExcelDataTypesViewModel : INotifyPropertyChanged
    {
        ICommand BrowseDirectory { get; }
        string ConfigurationDirectory { get; set; }
        string DataTypeConfigName { get; set; }
        ObservableCollection<IDataTypeConfigViewModel> ParameterSelections { get; }
        ICommand SaveDataTypes { get; }
        ObservableCollection<IExcelDataTypeListItemViewModel> SavedConfigurations { get; }
    }
}