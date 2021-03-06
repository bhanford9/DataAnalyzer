using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
  public class BorderSummaryItem : SummaryItem
  {
    public override bool IsApplicable(IActionParameters actionParameters)
    {
      return actionParameters is BorderParameters;
    }

    public override void SetDescription(IActionParameters actionParameters)
    {
      BorderParameters borderParameters = actionParameters as BorderParameters;

      this.Description =
        $"Left Color: {borderParameters.LeftColor}, Left Style: {borderParameters.LeftStyle}{Environment.NewLine}" +
        $"Top Color: {borderParameters.TopColor}, Top Style: {borderParameters.TopStyle}{Environment.NewLine}" +
        $"Right Color: {borderParameters.RightColor}, Right Style: {borderParameters.RightStyle}{Environment.NewLine}" +
        $"Bottom Color: {borderParameters.BottomColor}, Bottom Style: {borderParameters.BottomStyle}{Environment.NewLine}" +
        $"All Color: {borderParameters.AllColor}, All Style: {borderParameters.AllStyle}{Environment.NewLine}" +
        $"Diagonal Up Color: {borderParameters.DiagonalUpColor}, Diagonal Up Style: {borderParameters.DiagonalUpStyle}{Environment.NewLine}" +
        $"Diagonal Down Color: {borderParameters.DiagonalDownColor}, Diagonal Down Style: {borderParameters.DiagonalDownStyle}{Environment.NewLine}";

      if (borderParameters.Nth >= 0)
      {
        this.Description += $"Nth: {borderParameters.Nth}{Environment.NewLine}";
      }
    }
  }
}
