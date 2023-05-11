using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;

namespace ExcelService.Workbooks;

public sealed class StandardWorkbook : Workbook, IStandardWorkbook
{
    public StandardWorkbook(
      string filePath,
      ICollection<IWorksheet> worksheets,
      IActionDefinitions workbookActions = null)
      : base(filePath, worksheets, workbookActions)
    {
    }

    public override DocumentType DocumentType => DocumentType.Workbook;
}
