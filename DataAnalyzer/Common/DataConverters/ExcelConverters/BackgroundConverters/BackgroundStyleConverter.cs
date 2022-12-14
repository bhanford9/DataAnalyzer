﻿using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.BackgroundConverters
{
    internal class BackgroundStyleConverter : ExcelActionParamConverter
    {
        public BackgroundStyleConverter() : base(new BackgroundStyleParameters()) { }
        protected BackgroundStyleConverter(ExcelService.DataActions.ActionParameters.IActionParameters excelParams) : base(excelParams) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is BackgroundStyleParameters backgroundParameters)
            {
                return new BackgroundParameters()
                {
                    BackgroundColor = backgroundParameters.Color.ToSystemColor(),
                    FillPattern = FillPatternConverter.ToLocalFillPattern(backgroundParameters.Pattern.Type),
                    PatternColor = backgroundParameters.Pattern.Color.ToSystemColor(),
                    Name = backgroundParameters.Name
                };
            }

            throw new ArgumentException("Invalid type. Excpected BackgroundStyleParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BackgroundParameters backgroundParameters)
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

            throw new ArgumentException("Invalid type. Excpected BackgroundParameters.");
        }
    }
}
