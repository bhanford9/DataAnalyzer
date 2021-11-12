using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
  public class ExcelActionConverter
  {
    public static ExcelAction FromExcelActionInfo(ActionInfo actionInfo)
    {
      ExcelAction excelAction = new ExcelAction()
      {
        Description = actionInfo.Description,
        IsBuiltIn = true,
        Name = actionInfo.Name
      };

      // grabbing the defaults from the excel service may be overkill or even undesirable
      switch (actionInfo.DeaultParameters.Category)
      {
        case ActionCategory.AlignmentStyle:
          AlignmentStyleParameters excelAlignmentParams = actionInfo.DeaultParameters as AlignmentStyleParameters;
          excelAction.ActionParameters = new AlignmentParameters()
          {
            HorizontalAlignment = AlignmentConverters.ToLocalHorizontalAlignment(excelAlignmentParams.Alignments.HorizontalAlignment),
            VerticalAlignment = AlignmentConverters.ToLocalVerticalAlignment(excelAlignmentParams.Alignments.VerticalAlignment),
            Name = excelAlignmentParams.Name
          };
          break;
        case ActionCategory.BackgroundStyle:
          BackgroundStyleParameters excelBackgroundParams = actionInfo.DeaultParameters as BackgroundStyleParameters;
          excelAction.ActionParameters = new BackgroundParameters()
          {
            BackgroundColor = excelBackgroundParams.Color.ToSystemColor(),
            FillPattern = FillPatternConverter.ToLocalFillPattern(excelBackgroundParams.Pattern.Type),
            PatternColor = excelBackgroundParams.Pattern.Color.ToSystemColor(),
            Name = excelBackgroundParams.Name
          };
          break;
        case ActionCategory.BooleanOperation:
          excelAction.ActionParameters = new BooleanOperationParameters()
          {
            Name = actionInfo.Name
          };
          break;
        case ActionCategory.BorderStyle:
          BorderStyleParameters excelBorderParams = actionInfo.DeaultParameters as BorderStyleParameters;
          excelAction.ActionParameters = new BorderParameters()
          {
            LeftColor = excelBorderParams.
          };
          break;
        default:
          throw new System.Exception($"Unknown Action Category {actionInfo.DeaultParameters.Category}.");
      }

      return excelAction;
    }
  }
}
