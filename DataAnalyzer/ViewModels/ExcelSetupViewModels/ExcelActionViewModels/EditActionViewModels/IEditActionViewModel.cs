using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public interface IEditActionViewModel
  {
    string ActionName { get; set; }
    IActionParameters ActionParameters { get; set; }
    string Description { get; set; }
    ICommand Act { get; }

    IEditActionViewModel GetNewInstance(IActionParameters parameters);
    bool IsApplicable(IActionParameters parameters);
  }
}