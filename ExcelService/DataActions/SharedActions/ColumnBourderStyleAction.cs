//using ClosedXML.Excel;
//using ExcelService.DataActions.ActionParameters;
//using ExcelService.DataClusters;
//using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
//using ExcelService.Utilities;
//using System.Linq;

//namespace ExcelService.DataActions.SharedActions
//{
//    internal class ColumnBorderStyleAction : BorderStyleAction
//    {
//        public override string GetName()
//        {
//            return "Column Border Style";
//        }

//        public override string GetDescription()
//        {
//            return "Sets the color and style of the Border(s) for a Data Cluster's Column";
//        }

//        public override IActionParameters GetDefaultParameters()
//        {
//            return new ColumnBorderStyleParameters();
//        }

//        public override bool IsApplicable(IActionParameters parameters)
//        {
//            return IsCorrectType(parameters, typeof(ColumnBorderStyleParameters)) &&
//              parameters.Performer == ActionPerformer.DataCluster;
//        }

//        public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
//        {
//            if (excelEntity is IDataCluster)
//            {
//                message = string.Empty;
//                return true;
//            }

//            message = "Excel entity must be a DataCluster";
//            return false;
//        }

//        public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
//        {
//            ColumnBorderStyleParameters borderStyleParameters = parameters as ColumnBorderStyleParameters;
//            IDataCluster dataCluster = excelEntity as IDataCluster;
//            int columnNumber = -1;

//            if (borderStyleParameters.ColumnSpecification.UseNthColumn)
//            {
//                if (dataCluster.EndColNumber < borderStyleParameters.ColumnSpecification.NthColumn)
//                {
//                    message = $"Cannot assign border style to column number {borderStyleParameters.ColumnSpecification.NthColumn}. " +
//                      $"The last column number in the data range is column {dataCluster.EndColNumber}.";
//                    return false;
//                }
//                if (borderStyleParameters.ColumnSpecification.NthColumn < 1)
//                {
//                    message = "Cannot assign border style to a column number less than 1.";
//                    return false;
//                }

//                columnNumber = borderStyleParameters.ColumnSpecification.NthColumn;
//            }
//            else if (borderStyleParameters.ColumnSpecification.UseColumnAddress)
//            {
//                int specColNumber = ColumnConversions.NameToNumber(borderStyleParameters.ColumnSpecification.ColumnAddress);

//                if (dataCluster.EndColNumber < specColNumber)
//                {
//                    message = $"Cannot assign border style to column number {borderStyleParameters.ColumnSpecification.NthColumn}. " +
//                      $"The last column number in the data range is column {dataCluster.EndColNumber}.";
//                    return false;
//                }

//                columnNumber = specColNumber;
//            }
//            else if (borderStyleParameters.ColumnSpecification.UseColumnHeader)
//            {
//                int specColNumber = dataCluster.Titles
//                    .Select(x => x.Value.ToString())
//                    .ToList()
//                    .IndexOf(borderStyleParameters.ColumnSpecification.ColumnHeader);

//                if (specColNumber == -1)
//                {
//                    message = $"Column header with name of {borderStyleParameters.ColumnSpecification.ColumnHeader} was not found. " +
//                        $"Cannot apply border style.";
//                    return false;
//                }

//                columnNumber = specColNumber;
//            }

//            ICellRange cellRange = excelEntity as ICellRange;
//            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(borderStyleParameters.WorksheetName);

//            IXLRange range = worksheet.Range(
//              cellRange.StartRowNumber,
//              cellRange.StartColNumber,
//              cellRange.EndRowNumber,
//              cellRange.EndColNumber);

//            IXLRangeColumn columnToBorder = range.Column(columnNumber);

//            ApplyBorder(columnToBorder, borderStyleParameters);

//            message = string.Empty;
//            return true;
//        }
//    }
//}
