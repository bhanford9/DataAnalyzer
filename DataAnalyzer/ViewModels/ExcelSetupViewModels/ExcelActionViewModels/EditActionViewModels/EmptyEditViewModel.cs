using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class EmptyEditViewModel : EditActionViewModel
    {
        public override void ApplyParameterSettings()
        {
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            return new EmptyEditViewModel();
        }

        public override bool IsApplicable(IActionParameters parameters)
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
