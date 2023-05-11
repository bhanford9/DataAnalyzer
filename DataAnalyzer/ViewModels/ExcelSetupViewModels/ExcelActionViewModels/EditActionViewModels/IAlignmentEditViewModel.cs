using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;

internal interface IAlignmentEditViewModel : IEditActionViewModel
{
    IColumnSpecificationViewModel ColumnSpecification { get; set; }
    ObservableCollection<string> HorizontalAlignments { get; }
    IRowSpecificationViewModel RowSpecification { get; set; }
    string SelectedHorizontalAlignment { get; set; }
    string SelectedVerticalAlignment { get; set; }
    ObservableCollection<string> VerticalAlignments { get; }
}