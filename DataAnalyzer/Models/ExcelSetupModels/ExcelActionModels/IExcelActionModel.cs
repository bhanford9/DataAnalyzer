using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;

internal interface IExcelActionModel : INotifyPropertyChanged
{
    string LoadedActionName { get; set; }

    IExcelAction GetLoadedAction();
    void LoadAction(string name);
}