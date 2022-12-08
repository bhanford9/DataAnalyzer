using ExcelService.DataClusters;
using System.Collections.Generic;

namespace ExcelService.Worksheets
{
    public interface IWorksheet : IExcelEntity
    {
        ICollection<IDataCluster> DataClusters { get; }
        string SheetName { get; }
    }
}