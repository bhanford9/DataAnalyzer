using ExcelService.DataActions.ActionParameters;
using ExcelService.Rows;
using System.Collections.Generic;
using System.Linq;

namespace ExcelService.DataClusters
{
  public class UniformDataCluster : DataCluster
  {
    public UniformDataCluster(
      ICollection<IRow> rows,
      string clusterId,
      int startRowIndex,
      int startColIndex,
      IRow headers,
      IActionDefinitions clusterActions = null,
      bool useClusterId = true)
      : base(rows, clusterId, startRowIndex, startColIndex, headers, clusterActions, useClusterId)
    {
      this.ValidateRows(rows);
    }

    public UniformDataCluster(
      ICollection<IRow> rows,
      string clusterId,
      int startRowIndex,
      int startColIndex,
      bool generateHeaders = true,
      IActionDefinitions clusterActions = null,
      bool useClusterId = true)
      : base(rows, clusterId, startRowIndex, startColIndex, generateHeaders, clusterActions, useClusterId)
    {
      this.ValidateRows(rows);
    }

    private void ValidateRows(ICollection<IRow> rows)
    {
      if (rows.Count > 0)
      {
        IRow first = rows.First();

        rows.ToList().ForEach(row =>
        {
          if (row.Count != first.Count)
          {
            throw new System.Exception("All rows in cluster must have the same number of cells");
          }

          for (int i = 0; i < row.Count; i++)
          {
            if (!first.ElementAt(i).ColumnId.Equals(row.ElementAt(i).ColumnId))
            {
              throw new System.Exception("The cells of every row must be contain like Column Ids and they must be in the same order");
            }
          }
        });
      }
    }
  }
}
