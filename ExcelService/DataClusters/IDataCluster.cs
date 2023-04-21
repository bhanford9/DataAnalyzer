using ExcelService.Rows;

namespace ExcelService.DataClusters
{
    public interface IDataCluster : ICellRange
    {
        string ClusterHeader { get; }
        IRow Titles { get; }
        ICollection<IRow> Rows { get; }
        bool UseClusterHeader { get; }
        IRow HeaderRange { get; set; }
    }
}