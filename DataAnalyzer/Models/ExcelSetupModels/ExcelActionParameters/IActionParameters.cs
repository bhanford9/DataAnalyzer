using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public interface IActionParameters : ISerializablePropertyChanged
  {
    string Name { get; set; }

    ActionCategory ActionCategory { get; }
  }
}