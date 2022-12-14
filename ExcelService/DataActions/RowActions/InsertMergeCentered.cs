using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions.RowActions
{
    internal class InsertMergeCentered : DataAction
    {
        public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            throw new System.NotImplementedException();
        }

        public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            throw new System.NotImplementedException();
        }

        public override IActionParameters GetDefaultParameters()
        {
            throw new System.NotImplementedException();
        }

        public override string GetDescription()
        {
            throw new System.NotImplementedException();
        }

        public override string GetName()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsApplicable(IActionParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public override bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
