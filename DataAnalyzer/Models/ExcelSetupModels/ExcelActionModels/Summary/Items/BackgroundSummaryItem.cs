using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items;

internal class BackgroundSummaryItem : SummaryItem, IBackgroundSummaryItem
{
    public override bool IsApplicable(IActionParameters actionParameters) => actionParameters is BackgroundParameters;

    public override void SetDescription(IActionParameters actionParameters)
    {
        BackgroundParameters backgroundParameters = actionParameters as BackgroundParameters;

        this.Description =
          $"Background Color: {backgroundParameters.BackgroundColor}{Environment.NewLine}" +
          $"Background Pattern: {backgroundParameters.PatternColor}{Environment.NewLine}" +
          $"Pattern Fill: {backgroundParameters.FillPattern}{Environment.NewLine}" +
          $"{backgroundParameters.ColumnSpecification}{Environment.NewLine}" +
          $"{backgroundParameters.RowSpecification}{Environment.NewLine}";
    }
}
