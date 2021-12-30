using DataAnalyzer.Services;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public interface IActionParameters : INotifyPropertyChanged
  {
    string Name { get; set; }

    ActionCategory ActionCategory { get; }
  }
}