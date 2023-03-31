using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal interface IExcelSetupModel : INotifyPropertyChanged
    {
        ObservableCollection<IExcelAction> AvailableCellActions { get; }
        ObservableCollection<IExcelAction> AvailableDataClusterActions { get; }
        ObservableCollection<IExcelAction> AvailableRowActions { get; }
        ObservableCollection<IExcelAction> AvailableWorkbookActions { get; }
        ObservableCollection<IExcelAction> AvailableWorksheetActions { get; }
        IExcelConfigurationModel ExcelConfiguration { get; }
        IList<ITypeParameter> WorkingParameterTypes { get; set; }

        void ApplyTypeParametersToConfig();
        void BroadcastExcelActionApplied(string actionAppliedKey);
        void BroadcastExcelDataTypeUpdated(string dataName);
        void LoadWorkbookConfiguration();
        void SaveWorkbookConfiguration(string configName);
        void UpdateDataTypeForMember(string memberName, ITypeParameter dataType);
    }
}