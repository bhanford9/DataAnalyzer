using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class EmptyEditViewModel : EditActionViewModel
    {
        public EmptyEditViewModel(ExcelEntityType excelEntityType)
            : base(excelEntityType)
        {
        }

        public override void ApplyParameterSettings()
        {
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            return new EmptyEditViewModel(this.ExcelEntityType);
        }

        protected override bool InternalIsApplicable(IActionParameters parameters)
        {
            return parameters is EmptyParameters;
        }

        protected override void DoAct()
        {
        }

        protected override void InternalInit(IEditActionViewModel toCopy)
        {
        }
    }
}
