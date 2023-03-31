using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
    internal class BorderSummaryItem : SummaryItem, IBorderSummaryItem
    {
        public override bool IsApplicable(IActionParameters actionParameters) => actionParameters is BorderParameters;

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
              $"Diagonal Down Color: {borderParameters.DiagonalDownColor}, Diagonal Down Style: {borderParameters.DiagonalDownStyle}{Environment.NewLine}" +
              $"{borderParameters.ColumnSpecification}{Environment.NewLine}" +
              $"{borderParameters.RowSpecification}{Environment.NewLine}";
        }
    }
}
