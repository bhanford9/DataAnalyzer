using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;

internal interface IBorderEditViewModel : IEditActionViewModel
{
    IBorderSettingsViewModel AllBorderSettings { get; }
    ObservableCollection<IBorderSettingsViewModel> BorderSettings { get; }
    IBorderSettingsViewModel BottomBorderSettings { get; }
    IColumnSpecificationViewModel ColumnSpecification { get; set; }
    IBorderSettingsViewModel DiagonalDownBorderSettings { get; }
    IBorderSettingsViewModel DiagonalUpBorderSettings { get; }
    IBorderSettingsViewModel LeftBorderSettings { get; }
    IBorderSettingsViewModel RightBorderSettings { get; }
    IRowSpecificationViewModel RowSpecification { get; set; }
    IBorderSettingsViewModel TopBorderSettings { get; }
}