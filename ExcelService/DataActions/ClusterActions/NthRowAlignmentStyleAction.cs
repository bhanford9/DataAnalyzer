using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataClusters;
using System.Linq;

namespace ExcelService.DataActions.ClusterActions
{
  public class NthRowAlignmentStyleAction : AlignmentStyleAction
  {
    public override string GetName()
    {
      return "Nth Row Alignment Style";
    }

    public override string GetDescription()
    {
      return "Sets the Horizontal and/or Vertical alignments for a Data Cluster's Nth Row";
    }

    public override IActionParameters GetDefaultParameters()
    {
      return new NthRowAlignmentStyleParameters();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return this.IsCorrectType(parameters, typeof(NthRowAlignmentStyleParameters)) &&
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
      NthRowAlignmentStyleParameters alignmentStyleParameters = parameters as NthRowAlignmentStyleParameters;
      IDataCluster dataCluster = excelEntity as IDataCluster;

      if (dataCluster.Rows.Count <= alignmentStyleParameters.NthRow)
      {
        message = $"Cannot assign alignment style to {alignmentStyleParameters.NthRow}. " +
          $"Only {dataCluster.Rows.Count} rows exist within Data Cluster.";
        return false;
      }

      return base.Execute(
        workbook,
        dataCluster.Rows.ElementAt(alignmentStyleParameters.NthRow),
        alignmentStyleParameters,
        out message);
    }
  }
}
