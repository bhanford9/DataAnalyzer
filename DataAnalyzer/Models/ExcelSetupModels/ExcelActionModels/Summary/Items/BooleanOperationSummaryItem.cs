using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
    internal class BooleanOperationSummaryItem : SummaryItem
    {
        public override bool IsApplicable(IActionParameters actionParameters)
        {
            return actionParameters is BooleanOperationParameters;
        }

        public override void SetDescription(IActionParameters actionParameters)
        {
            BooleanOperationParameters booleanOperationParameters = actionParameters as BooleanOperationParameters;

            this.Description =
              $"Background Color: {booleanOperationParameters.DoPerform}{Environment.NewLine}";
        }
    }
}
