using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;

namespace ExcelService.Workbooks;

public class TemplateWorkbook : Workbook, ITemplateWorkbook
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