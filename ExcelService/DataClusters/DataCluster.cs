using ExcelService.Cells;
using ExcelService.DataActions.ActionParameters;
using ExcelService.Rows;
using System.Collections.Generic;
using System.Linq;

namespace ExcelService.DataClusters
{
  public class DataCluster : ExcelEntity, IDataCluster
  {
    public DataCluster(
      ICollection<IRow> rows,
      string clusterHeader,
      int startRowIndex,
      int startColIndex,
      IRow titles,
      IActionDefinitions clusterActions = null,
      bool useClusterId = true)
    {
      this.Rows = rows;
      this.ClusterHeader = clusterHeader;
      this.StartRowNumber = startRowIndex + 1;
      this.StartColNumber = startColIndex + 1;
      this.Titles = titles;
      this.UseClusterHeader = useClusterId;

      if (clusterActions != null)
      {
        this.ActionDefinitions = clusterActions;
      }

      if (titles != null)
      {
        this.Rows = this.Rows.Prepend(titles).ToList();
      }
    }

    public DataCluster(
      ICollection<IRow> rows,
      string clusterHeader,
      int startRowIndex,
      int startColIndex,
      bool generateTitles = true,
      IActionDefinitions clusterActions = null,
      bool useClusterId = true)
    {
      this.Rows = rows;
      this.ClusterHeader = clusterHeader;
      this.StartRowNumber = startRowIndex + 1;
      this.StartColNumber = startColIndex + 1;
      this.UseClusterHeader = useClusterId;

      if (clusterActions != null)
      {
        this.ActionDefinitions = clusterActions;
      }

      if (generateTitles)
      {
        if (this.Rows.Count > 0)
        {
          //throw new System.Exception("Cannot generate titles for empty rowset");

          this.Titles = new Row(this.Rows.ElementAt(0).Select(cell => (ICell)new Cell(cell.ColumnId, cell.ColumnId)).ToList());
          this.Rows = this.Rows.Prepend(this.Titles).ToList();
        }
      }
    }

    public override string Name => "Data Cluster";

    public ICollection<IRow> Rows { get; } = new List<IRow>();

    public string ClusterHeader { get; } = string.Empty;

    public int StartRowNumber { get; set; } = 1;

    public int StartColNumber { get; set; } = 1;

    public int EndRowNumber => this.StartRowNumber + this.Rows.Count - 1;

    public int EndColNumber => this.Rows.Count == 0 ? this.StartColNumber : this.StartColNumber + this.Rows.ElementAt(0).Count - 1;

    public bool UseClusterHeader { get; } = true;

    public IRow Titles { get; } = null;

    public IRow HeaderRange { get; set; } = null;
  }
}
