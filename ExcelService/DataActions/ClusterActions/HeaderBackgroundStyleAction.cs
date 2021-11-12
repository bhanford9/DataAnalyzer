using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataClusters;

namespace ExcelService.DataActions.ClusterActions
{
  public class HeaderBackgroundStyleAction : BackgroundStyleAction
  {
    public override string GetName()
    {
      return "Header Background Style";
    }

    public override string GetDescription()
    {
      return "Sets the color and style of the background fill for a Data Cluster Header";
    }

    public override IActionParameters GetDefaultParameters()
    {
      return new HeaderBackgroundStyleParameters();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return this.IsCorrectType(parameters, typeof(HeaderBackgroundStyleParameters)) &&
        parameters.Performer == ActionPerformer.DataClusterHeader;
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
      IDataCluster dataCluster = excelEntity as IDataCluster;
      return base.Execute(workbook, dataCluster.HeaderRange, parameters, out message);
    }
  }
}