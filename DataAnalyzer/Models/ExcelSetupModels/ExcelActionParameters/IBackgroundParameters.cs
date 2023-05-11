using DataAnalyzer.Services.Enums;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal interface IBackgroundParameters : IActionParameters
{
    Color BackgroundColor { get; set; }
    IColumnSpecificationParameters ColumnSpecification { get; set; }
    FillPattern FillPattern { get; set; }
    Color PatternColor { get; set; }
    IRowSpecificationParameters RowSpecification { get; set; }
}