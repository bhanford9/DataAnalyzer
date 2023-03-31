using DataAnalyzer.Services.Enums;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal class BooleanOperationParameters : ActionParameters, IBooleanOperationParameters
    {
        private bool doPerform = false;

        public bool DoPerform
        {
            get => this.doPerform;
            set => this.NotifyPropertyChanged(ref this.doPerform, value);
        }

        public override ActionCategory ActionCategory => ActionCategory.BooleanOperation;

        public override string ToString() => $"Do Perform: {this.DoPerform}{Environment.NewLine}";

        public override IActionParameters Clone() =>
            new BooleanOperationParameters
            {
                ExcelEntityType = this.ExcelEntityType,
                Name = this.Name,
                DoPerform = this.doPerform
            };
    }
}
