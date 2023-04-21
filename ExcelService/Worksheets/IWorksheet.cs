using ExcelService.DataClusters;

namespace ExcelService.Worksheets
{
    public interface IWorksheet : IExcelEntity
    {
        ICollection<IDataCluster> DataClusters { get; }
        string SheetName { get; }
    }
}