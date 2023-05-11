using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;

internal class EmptyEditViewModel : EditActionViewModel, IEmptyEditViewModel
{
    public EmptyEditViewModel(IExcelEntitySpecification excelEntityType)
        : base(excelEntityType)
    {
    }

    public override void ApplyParameterSettings()
    {
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters) => new EmptyEditViewModel(this.ExcelEntityType);

    protected override bool InternalIsApplicable(IActionParameters parameters) => parameters is EmptyParameters;

    protected override void DoAct()
    {
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
    }
}
