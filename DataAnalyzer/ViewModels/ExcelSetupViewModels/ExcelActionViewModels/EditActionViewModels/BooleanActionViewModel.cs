using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Enums;
using System;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class BooleanActionViewModel : EditActionViewModel
    {
        private bool doPerform = false;

        public BooleanActionViewModel(ExcelEntityType excelEntityType) : base(excelEntityType)
        {
        }

        public BooleanActionViewModel(
            IActionCreationModel actionCreationModel,
            IEditActionViewModel toCopy,
            ExcelEntityType excelEntityType)
          : base(actionCreationModel, toCopy, excelEntityType)
        {
        }

        public bool DoPerform
        {
            get => this.doPerform;
            set => this.NotifyPropertyChanged(ref this.doPerform, value);
        }

        public override void ApplyParameterSettings()
        {
            BooleanOperationParameters booleanParameters = this.ActionParameters as BooleanOperationParameters;
            booleanParameters.DoPerform = this.DoPerform;
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            BooleanActionViewModel viewModel = new(this.actionCreationModel, this, this.ExcelEntityType);

            BooleanOperationParameters booleanParameters = parameters as BooleanOperationParameters;
            viewModel.DoPerform = booleanParameters.DoPerform;
            return viewModel;
        }

        protected override bool InternalIsApplicable(IActionParameters parameters) => parameters is BooleanOperationParameters;

        protected override void DoAct() => throw new NotImplementedException();

        protected override void InternalInit(IEditActionViewModel toCopy)
        {
        }
    }
}
