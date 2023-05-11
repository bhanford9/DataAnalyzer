using DataAnalyzer.Models.ExcelSetupModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;

internal class ExcelDataTypeListItemViewModel : LoadableRemovableRowViewModel, IExcelDataTypeListItemViewModel
{
    private readonly IExcelConfigurationModel excelConfigurationModel;

    public ExcelDataTypeListItemViewModel(IExcelConfigurationModel excelConfigurationModel)
    {
        this.excelConfigurationModel = excelConfigurationModel;
    }

    protected override void DoLoad() => this.excelConfigurationModel.LoadDataTypeConfigByName(this.Value);

    protected override void InternalDoRemove() =>
        // TODO --> prompt user with confirmation
        throw new NotImplementedException();
}
