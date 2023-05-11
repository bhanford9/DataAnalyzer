using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelService.Utilities;
using ExcelService.Workbooks;

namespace ExcelService;

public class OpenXmlExcelExecutive : IOpenXmlExcelExecutive
{
    public void GenerateWorkbook(IWorkbook workbook)
    {
        // The OpenXml library is probably structured based off of how Microsoft 
        // lays out the XML of different Office products. This makes the code
        // seem like overkill, but it works well with generating the underlying XML

        SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(
           workbook.FilePath,
           DocumentTypeUtilities.ToSpreadSheetType(workbook.DocumentType));

        WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
        workbookpart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

        for (int excelIndex = 1, codeIndex = 0; excelIndex <= workbook.Worksheets.Count; excelIndex++, codeIndex++)
        {
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
            sheets.Append(new Sheet
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = (uint)excelIndex,
                Name = workbook.Worksheets.ElementAt(codeIndex).SheetName
            });

            workbook.Worksheets.ElementAt(codeIndex).DataClusters.ToList().ForEach(dataCluster =>
            {
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();

                int startRowNumber = dataCluster.StartRowNumber + 1;
                int endRowNumber = startRowNumber + dataCluster.Rows.Count;
                for (int rowIndex = 0, rowNumber = startRowNumber; rowNumber < endRowNumber; rowIndex++, rowNumber++)
                {
                    int columnNumber = 1;
                    string columnName = ColumnConversions.NumberToName(dataCluster.StartColNumber);

                    Row row = new Row { RowIndex = (uint)rowNumber };
                    sheetData.Append(row);

                    dataCluster.Rows.ElementAt(rowIndex).ToList().ForEach(cell =>
            {
                string cellReference = columnName + rowNumber;
                _ = row.AppendChild(new Cell
                {
                    CellReference = cellReference,
                    DataType = CellValues.InlineString,
                    InlineString = new InlineString { Text = new Text(cell.Value.ToString()) }
                });

                columnName = ColumnConversions.NumberToName(++columnNumber);
            });
                }
            });
        }


        workbookpart.Workbook.Save();
        spreadsheetDocument.Close();
    }

    public void GenerateWorkbooks(ICollection<IWorkbook> workbooks)
    {

    }
}
