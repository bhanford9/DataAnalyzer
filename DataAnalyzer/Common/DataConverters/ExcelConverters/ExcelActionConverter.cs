﻿using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
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