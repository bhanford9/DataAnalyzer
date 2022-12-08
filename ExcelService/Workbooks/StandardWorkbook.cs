using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;
using System.Collections.Generic;

namespace ExcelService.Workbooks
{
    public sealed class StandardWorkbook : Workbook
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
}
