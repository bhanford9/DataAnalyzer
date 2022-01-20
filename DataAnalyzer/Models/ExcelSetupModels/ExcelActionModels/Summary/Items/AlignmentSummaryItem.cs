using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
  public class AlignmentSummaryItem : SummaryItem
  {
    public override bool IsApplicable(IActionParameters actionParameters)
    {
      return actionParameters is AlignmentParameters;
    }

    public override void SetDescription(IActionParameters actionParameters)
    {
      AlignmentParameters alignmentParameters = actionParameters as AlignmentParameters;
      this.Description =
        $"Horizontal Alignment: {alignmentParameters.HorizontalAlignment}{Environment.NewLine}" +
        $"Vertical Alignment: {alignmentParameters.VerticalAlignment}{Environment.NewLine}";

      if (alignmentParameters.Nth >= 0)
      {
        this.Description += $"Nth: {alignmentParameters.Nth}{Environment.NewLine}";
      }
    }
  }
}
