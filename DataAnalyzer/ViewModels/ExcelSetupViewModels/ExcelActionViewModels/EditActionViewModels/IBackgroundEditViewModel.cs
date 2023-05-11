using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;

internal interface IBackgroundEditViewModel : IEditActionViewModel
{
    IColorsComboBoxViewModel BackgroundColors { get; }
    IColumnSpecificationViewModel ColumnSpecification { get; set; }
    IColorsComboBoxViewModel PatternColors { get; }
    ObservableCollection<string> Patterns { get; }
    IRowSpecificationViewModel RowSpecification { get; set; }
    string SelectedPattern { get; set; }
}