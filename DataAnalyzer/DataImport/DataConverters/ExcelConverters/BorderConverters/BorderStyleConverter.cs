using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.UtilityConverters;
using ExcelParms = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.BorderConverters
{
    internal class BorderStyleConverter : ExcelActionParamConverter, IBorderStyleConverter
    {
        public BorderStyleConverter() : base(new BorderStyleParameters()) { }
        protected BorderStyleConverter(ExcelParms.IActionParameters excelParams) : base(excelParams) { }

        public override IActionParameters FromExcel(ExcelParms.IActionParameters input)
        {
            if (input is BorderStyleParameters excelBorderParams)
            {
                return new BorderParameters
                {
                    LeftColor = excelBorderParams.Left.Color.ToSystemColor(),
                    LeftStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.Left.Style),

                    TopColor = excelBorderParams.Top.Color.ToSystemColor(),
                    TopStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.Top.Style),

                    RightColor = excelBorderParams.Right.Color.ToSystemColor(),
                    RightStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.Right.Style),

                    BottomColor = excelBorderParams.Bottom.Color.ToSystemColor(),
                    BottomStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.Bottom.Style),

                    AllColor = excelBorderParams.AllBorders.Color.ToSystemColor(),
                    AllStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.AllBorders.Style),

                    DiagonalUpColor = excelBorderParams.DiagonalUp.Color.ToSystemColor(),
                    DiagonalUpStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.DiagonalUp.Style),

                    DiagonalDownColor = excelBorderParams.DiagonalDown.Color.ToSystemColor(),
                    DiagonalDownStyle = BorderTypesConverter.ToLocalBorderStyle(excelBorderParams.DiagonalDown.Style),

                    ColumnSpecification = ColumnSpecificationConverter.ToLocalColumnSpecification(excelBorderParams.ColumnSpecification),
                    RowSpecification = RowSpecificationConverter.ToLocalRowSpecification(excelBorderParams.RowSpecification),

                    Name = excelBorderParams.Name
                };
            }

            throw new ArgumentException("Invalid type. Expected BorderStyleParameters.");
        }

        public override ExcelParms.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BorderParameters borderParameters)
            {
                return new BorderStyleParameters
                {
                    AllBorders = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.AllColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.AllStyle)
                    },
                    Bottom = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.BottomColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.BottomStyle)
                    },
                    DiagonalDown = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.DiagonalDownColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.DiagonalDownStyle)
                    },
                    DiagonalUp = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.DiagonalUpColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.DiagonalUpStyle)
                    },
                    Left = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.LeftColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.LeftStyle)
                    },
                    Right = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.RightColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.RightStyle)
                    },
                    Top = new ExcelService.Styles.Borders.Border
                    {
                        DoApply = true,
                        Color = ExcelColorValueConverter.ToExcelColorValue(borderParameters.TopColor),
                        Style = BorderTypesConverter.ToExcelBorderStyle(borderParameters.TopStyle)
                    },
                    ColumnSpecification = ColumnSpecificationConverter.ToExcelColumnSpecification(borderParameters.ColumnSpecification),
                    RowSpecification = RowSpecificationConverter.ToExcelRowSpecification(borderParameters.RowSpecification)
                };
            }

            throw new ArgumentException("Invalid type. Expected BorderParameters.");
        }
    }
}
