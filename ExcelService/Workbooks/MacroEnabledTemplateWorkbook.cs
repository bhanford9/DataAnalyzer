using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;


namespace ExcelService.Workbooks
{
    public class MacroEnabledTemplateWorkbook : Workbook, IMacroEnabledTemplateWorkbook
    {
        public MacroEnabledTemplateWorkbook(
          string filePath,
          ICollection<IWorksheet> worksheets,
          IActionDefinitions workbookActions = null)
          : base(filePath, worksheets, workbookActions)
        {
        }

        public override DocumentType DocumentType => DocumentType.MacroEnabledTemplate;
    }
}
