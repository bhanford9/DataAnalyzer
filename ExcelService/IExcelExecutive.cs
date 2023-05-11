using ExcelService.Workbooks;

namespace ExcelService;

public interface IExcelExecutive
{
    void GenerateWorkbook(IWorkbook workbook);
    void GenerateWorkbooks(ICollection<IWorkbook> workbooks);
}