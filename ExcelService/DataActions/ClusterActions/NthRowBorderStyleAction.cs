using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataClusters;
using System.Linq;

namespace ExcelService.DataActions.ClusterActions
{
  class NthRowBorderStyleAction : BorderStyleAction
  {
    public override string GetName()
    {
      return "Nth Row Border Style";
    }

    public override string GetDescription()
    {
      return "Sets the color and style of the Border(s) for a Data Cluster's Nth Row";
    }

    public override IActionParameters GetDefaultParameters()
    {
      return new NthRowBorderStyleParameters();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return this.IsCorrectType(parameters, typeof(NthRowBorderStyleParameters)) &&
        parameters.Performer == ActionPerformer.DataCluster;
    }

    public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
    {
      if (excelEntity is IDataCluster)
      {
        message = string.Empty;
        return true;
      }

      message = "Excel entity must be a DataCluster";
      return false;
    }

    public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
    {
      NthRowBorderStyleParameters borderStyleParameters = parameters as NthRowBorderStyleParameters;
      IDataCluster dataCluster = excelEntity as IDataCluster;

      if (dataCluster.Rows.Count <= borderStyleParameters.NthRow)
      {
        message = $"Cannot assign border style to {borderStyleParameters.NthRow}. " +
          $"Only {dataCluster.Rows.Count} rows exist within Data Cluster.";
        return false;
      }

      return base.Execute(
        workbook,
        dataCluster.Rows.ElementAt(borderStyleParameters.NthRow),
        borderStyleParameters,
        out message);
    }
  }
}
