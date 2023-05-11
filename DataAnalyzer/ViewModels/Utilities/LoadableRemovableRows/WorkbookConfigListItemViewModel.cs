using DataAnalyzer.Models.ExcelSetupModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;

internal class WorkbookConfigListItemViewModel : LoadableRemovableRowViewModel, IWorkbookConfigListItemViewModel
{
    private readonly IExcelConfigurationModel excelConfigurationModel;

    public WorkbookConfigListItemViewModel(IExcelConfigurationModel excelConfigurationModel)
    {
        this.excelConfigurationModel = excelConfigurationModel;
    }

    protected override void DoLoad() => this.excelConfigurationModel.LoadWorkbookConfigByName(this.Value);

    protected override void InternalDoRemove() =>
        // TODO --> prompt user with confirmation
        throw new NotImplementedException();
}
