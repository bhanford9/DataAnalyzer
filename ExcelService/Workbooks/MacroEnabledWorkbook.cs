using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;
using System.Collections.Generic;

namespace ExcelService.Workbooks
{
    class MacroEnabledWorkbook : Workbook
    {
        public MacroEnabledWorkbook(
          string filePath,
          ICollection<IWorksheet> worksheets,
          IActionDefinitions workbookActions = null)
          : base(filePath, worksheets, workbookActions)
        {
        }

        public override DocumentType DocumentType => DocumentType.MacroEnabledWorkbook;
    }
}
