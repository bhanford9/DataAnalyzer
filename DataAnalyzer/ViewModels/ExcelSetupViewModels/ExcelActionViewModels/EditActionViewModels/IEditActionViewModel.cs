using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal interface IEditActionViewModel
    {
        string ActionName { get; set; }
        IActionParameters ActionParameters { get; set; }
        string Description { get; set; }
        ICommand Act { get; }

        void ApplyParameterSettings();
        IEditActionViewModel GetNewInstance(IActionParameters parameters);
        bool IsApplicable(IActionParameters parameters);
    }
}