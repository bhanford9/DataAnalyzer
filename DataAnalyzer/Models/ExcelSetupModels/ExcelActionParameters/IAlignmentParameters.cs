using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal interface IAlignmentParameters : IActionParameters
{
    IColumnSpecificationParameters ColumnSpecification { get; set; }
    HorizontalAlignment HorizontalAlignment { get; set; }
    IRowSpecificationParameters RowSpecification { get; set; }
    VerticalAlignment VerticalAlignment { get; set; }
}