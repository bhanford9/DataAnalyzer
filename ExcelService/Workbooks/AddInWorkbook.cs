using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;
using System.Collections.Generic;

namespace ExcelService.Workbooks
{
    class AddInWorkbook : Workbook
    {
        public AddInWorkbook(
          string filePath,
          ICollection<IWorksheet> worksheets,
          IActionDefinitions workbookActions = null)
          : base(filePath, worksheets, workbookActions)
        {
        }

        public override DocumentType DocumentType => DocumentType.AddIn;
    }
}
