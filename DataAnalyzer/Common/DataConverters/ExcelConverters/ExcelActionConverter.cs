using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
  public class ExcelActionConverter
  {
    public static AlignmentStyleParameters ToExcelAlignmentParameters(AlignmentParameters alignmentParameters)
    {
      return new AlignmentStyleParameters()
      {
        Alignments = new ExcelService.Styles.Alignments.AlignmentValues()
        {
          DoApplyHorizontal = true,
          DoApplyVertical = true,
          HorizontalAlignment = AlignmentConverters.ToExcelHorizontalAlignment(alignmentParameters.HorizontalAlignment),
          VerticalAlignment = AlignmentConverters.ToExcelVerticalAlignment(alignmentParameters.VerticalAlignment),
        },
      };
    }

    public static NthRowAlignmentStyleParameters ToExcelNthRowAlignmentParameters(AlignmentParameters alignmentParameters)
    {
      AlignmentStyleParameters alignmentStyle = ToExcelAlignmentParameters(alignmentParameters);
      return new NthRowAlignmentStyleParameters()
      {
        Alignments = alignmentStyle.Alignments,
        NthRow = alignmentParameters.Nth
      };
    }

    public static BackgroundStyleParameters ToExcelBackgroundParameters(BackgroundParameters backgroundParameters)
    {
      return new BackgroundStyleParameters()
      {
        DoApplyColor = true,
        Color = ExcelColorValueConverter.ToExcelColorValue(backgroundParameters.BackgroundColor),
        Pattern = new ExcelService.Styles.Patterns.FillPatternValue()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(backgroundParameters.PatternColor),
          Type = FillPatternConverter.ToExcelFillPattern(backgroundParameters.FillPattern),
        }
      };
    }

    public static BorderStyleParameters ToExcelBorderParameters(BorderParameters borderParameters)
    {
      return new BorderStyleParameters()
      {
        AllBorders = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.AllColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.AllStyle)
        },
        Bottom = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.BottomColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.BottomStyle)
        },
        DiagonalDown = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.DiagonalDownColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.DiagonalDownStyle)
        },
        DiagonalUp = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.DiagonalUpColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.DiagonalUpStyle)
        },
        Left = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.LeftColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.LeftStyle)
        },
        Right = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.RightColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.RightStyle)
        },
        Top = new ExcelService.Styles.Borders.Border()
        {
          DoApply = true,
          Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.TopColor),
          Style = BorderStyleConverter.ToExcelBorderStyle(borderParameters.TopStyle)
        }
      };
    }

    public static NthRowBorderStyleParameters ToExcelNthRowBorderParameters(BorderParameters borderParameters)
    {
      BorderStyleParameters borderStyle = ToExcelBorderParameters(borderParameters);

      return new NthRowBorderStyleParameters()
      {
        AllBorders = borderStyle.AllBorders,

        Bottom = borderStyle.AllBorders,
        DiagonalDown = borderStyle.DiagonalDown,
        DiagonalUp = borderStyle.DiagonalUp,
        Left = borderStyle.Left,
        Right = borderStyle.Right,
        Top = borderStyle.Top,
        NthRow = borderParameters.Nth
      };
    }

    public static ExcelService.DataActions.ActionParameters.IActionParameters ToExcelActionDefinition(Models.ExcelSetupModels.ExcelActionParameters.IActionParameters actionParameters)
    {
      ExcelService.DataActions.ActionParameters.IActionParameters actionParams = null;

      switch (actionParameters.ActionCategory)
      {
        case Services.ActionCategory.AlignmentStyle:
          AlignmentParameters alignmentParams = actionParameters as AlignmentParameters;
          return alignmentParams.Nth >= 0 ?
            ToExcelNthRowAlignmentParameters(alignmentParams) :
            ToExcelAlignmentParameters(alignmentParams);

        case Services.ActionCategory.BackgroundStyle:
          return ToExcelBackgroundParameters(actionParameters as BackgroundParameters);

        case Services.ActionCategory.BooleanOperation:
          BooleanOperationParameters booleanOperationParameters = actionParameters as BooleanOperationParameters;
          // not sure yet
          return actionParams;

        case Services.ActionCategory.BorderStyle:
          BorderParameters borderParams = actionParameters as BorderParameters;
          return borderParams.Nth >= 0 ?
            ToExcelNthRowBorderParameters(borderParams) :
            ToExcelBorderParameters(borderParams);

        case Services.ActionCategory.ColumnBorderStyle:
          ColumnBorderStyleParameters columnBorderStyleParameters = actionParameters as ColumnBorderStyleParameters;
          // not sure yet
          return actionParams;
        case Services.ActionCategory.Unknown:
        default:
          return actionParams;
      }
    }

    public static IActionDefinitions ToExcelDefinitions(ICollection<Models.ExcelSetupModels.ExcelActionParameters.IActionParameters> actionsParameters)
    {
      return new ActionDefinitions(actionsParameters.Select(x => ToExcelActionDefinition(x)).ToList());
    }

    public static ExcelAction FromExcelActionInfo(ActionInfo actionInfo)
    {
      ExcelAction excelAction = new ExcelAction()
      {
        Description = actionInfo.Description,
        IsBuiltIn = true,
        Name = actionInfo.Name,
      };

      // grabbing the defaults from the excel service may be overkill or even undesirable
      switch (actionInfo.DefaultParameters.Category)
      {
        case ActionCategory.AlignmentStyle:
          AlignmentStyleParameters excelAlignmentParams = actionInfo.DefaultParameters as AlignmentStyleParameters;
          excelAction.ActionParameters = new AlignmentParameters()
          {
            HorizontalAlignment = AlignmentConverters.ToLocalHorizontalAlignment(excelAlignmentParams.Alignments.HorizontalAlignment),
            VerticalAlignment = AlignmentConverters.ToLocalVerticalAlignment(excelAlignmentParams.Alignments.VerticalAlignment),
            Name = excelAlignmentParams.Name
          };

          if (actionInfo.DefaultParameters is NthRowAlignmentStyleParameters nthAlignmentParams)
          {
            (excelAction.ActionParameters as AlignmentParameters).Nth = nthAlignmentParams.NthRow;
          }
          break;
        case ActionCategory.BackgroundStyle:
          BackgroundStyleParameters excelBackgroundParams = actionInfo.DefaultParameters as BackgroundStyleParameters;
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
          BorderStyleParameters excelBorderParams = actionInfo.DefaultParameters as BorderStyleParameters;
          excelAction.ActionParameters = new BorderParameters()
          {
            LeftColor = excelBorderParams.Left.Color.ToSystemColor(),
            LeftStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.Left.Style),

            TopColor = excelBorderParams.Top.Color.ToSystemColor(),
            TopStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.Top.Style),

            RightColor = excelBorderParams.Right.Color.ToSystemColor(),
            RightStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.Right.Style),

            BottomColor = excelBorderParams.Bottom.Color.ToSystemColor(),
            BottomStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.Bottom.Style),

            AllColor = excelBorderParams.AllBorders.Color.ToSystemColor(),
            AllStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.AllBorders.Style),

            DiagonalUpColor = excelBorderParams.DiagonalUp.Color.ToSystemColor(),
            DiagonalUpStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.DiagonalUp.Style),

            DiagonalDownColor = excelBorderParams.DiagonalDown.Color.ToSystemColor(),
            DiagonalDownStyle = BorderStyleConverter.ToLocalBorderStyle(excelBorderParams.DiagonalDown.Style),

            Name = excelBorderParams.Name
          };

          if (actionInfo.DefaultParameters is NthRowBorderStyleParameters nthBorderParams)
          {
            (excelAction.ActionParameters as BorderParameters).Nth = nthBorderParams.NthRow;
          }
          break;
        case ActionCategory.ColumnBorderStyle:
          break;
        default:
          throw new System.Exception($"Unknown Action Category {actionInfo.DefaultParameters.Category}.");
      }

      return excelAction;
    }
  }
}
