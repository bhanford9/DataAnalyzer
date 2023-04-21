using ExcelService.Utilities;
using ExcelService.Worksheets;

namespace ExcelService.Workbooks
{
    public interface IWorkbook : IExcelEntity
    {
        DocumentType DocumentType { get; }
        string FilePath { get; }
        string FileName { get; }
        ICollection<IWorksheet> Worksheets { get; }

        bool IsValidFilePath(string filePath);
    }
}