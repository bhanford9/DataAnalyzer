using ExcelService.DataActions.ActionParameters;
using ExcelService.DataClusters;

namespace ExcelService.Worksheets
{
    public class Worksheet : ExcelEntity, IWorksheet
    {
        public Worksheet(
          string name,
          ICollection<IDataCluster> dataClusters,
          IActionDefinitions worksheetActions = null)
        {
            this.SheetName = name;
            this.DataClusters = dataClusters;

            if (worksheetActions != null)
            {
                this.ActionDefinitions = worksheetActions;
            }
        }

        public string SheetName { get; } = string.Empty;

        public ICollection<IDataCluster> DataClusters { get; } = new List<IDataCluster>();
    }
}
