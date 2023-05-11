﻿using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Services.ExcelUtilities;
using ExcelService.DataActions;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters;

internal class ExcelActionConverter
{
    public static ExcelAction FromExcelActionInfo(ActionInfo actionInfo, IExcelEntitySpecification excelEntityType)
        => new()
        {
            Description = actionInfo.Description,
            IsBuiltIn = true,
            Name = actionInfo.Name,
            ActionParameters = ExcelActionParamConverters.FromExcel(actionInfo.DefaultParameters).WithExcelEntity(excelEntityType)
        };
}
