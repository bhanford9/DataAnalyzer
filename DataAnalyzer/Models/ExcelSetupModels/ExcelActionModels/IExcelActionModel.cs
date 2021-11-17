using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public interface IExcelActionModel : INotifyPropertyChanged
  {
    string LoadedActionName { get; set; }

    ExcelAction GetLoadedAction();
    void LoadAction(string name);
  }
}