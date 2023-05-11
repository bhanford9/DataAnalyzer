using DataAnalyzer.Services.Enums;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal interface IBorderParameters : IActionParameters
{
    Color AllColor { get; set; }
    BorderStyle AllStyle { get; set; }
    Color BottomColor { get; set; }
    BorderStyle BottomStyle { get; set; }
    IColumnSpecificationParameters ColumnSpecification { get; set; }
    Color DiagonalDownColor { get; set; }
    BorderStyle DiagonalDownStyle { get; set; }
    Color DiagonalUpColor { get; set; }
    BorderStyle DiagonalUpStyle { get; set; }
    Color LeftColor { get; set; }
    BorderStyle LeftStyle { get; set; }
    Color RightColor { get; set; }
    BorderStyle RightStyle { get; set; }
    IRowSpecificationParameters RowSpecification { get; set; }
    Color TopColor { get; set; }
    BorderStyle TopStyle { get; set; }
}