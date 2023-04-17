namespace DataAnalyzer.Services.ExcelUtilities
{
    public interface IExcelEntitySpecification
    {
        string Name { get; }

        static IExcelEntitySpecification Workbook { get; } = new ExcelWorkbookSpecification();
        static IExcelEntitySpecification Worksheet { get; } = new ExcelWorksheetSpecification();
        static IExcelEntitySpecification DataCluster { get; } = new ExcelDataClusterSpecification();
        static IExcelEntitySpecification Row { get; } = new ExcelRowSpecification();
        static IExcelEntitySpecification Cell { get; } = new ExcelCellSpecification();
    }
}
