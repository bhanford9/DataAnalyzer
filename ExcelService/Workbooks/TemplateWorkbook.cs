using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;
using System.Collections.Generic;

namespace ExcelService.Workbooks
{
  public class TemplateWorkbook : Workbook
  {
    public TemplateWorkbook(
      string filePath,
      ICollection<IWorksheet> worksheets,
      IActionDefinitions workbookActions = null)
      : base(filePath, worksheets, workbookActions)
    {
    }

    public override DocumentType DocumentType => DocumentType.Template;
  }
}