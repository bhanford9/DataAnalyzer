using ExcelService.Workbooks;

namespace ExcelService;

internal interface IOpenXmlExcelExecutive
{
    void GenerateWorkbook(IWorkbook workbook);
    void GenerateWorkbooks(ICollection<IWorkbook> workbooks);
}