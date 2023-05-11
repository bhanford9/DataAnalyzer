using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataClusters;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ClusterActions;

public class HeaderMergeCenterFullAction : DataAction, IHeaderMergeCenterFullAction
{
    public override string GetName()
    {
        return "Merge & Center Cluster Header";
    }

    public override string GetDescription()
    {
        return "Merges the Cluster's header across the full width and centers the text";
    }

    public override IActionParameters GetDefaultParameters()
    {
        return new HeaderMergeCenterFullParameters();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
        return this.IsCorrectType(parameters, typeof(HeaderMergeCenterFullParameters)) &&
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

        string startLetter = ColumnConversions.NumberToName(dataCluster.StartColNumber);
        string endLetter = ColumnConversions.NumberToName(dataCluster.StartColNumber + dataCluster.Rows.ElementAt(0).Count - 1);

        int clusterIdRowNumber = dataCluster.StartRowNumber - 1;
        string startReference = startLetter + clusterIdRowNumber;
        string endReference = endLetter + clusterIdRowNumber;

        IXLRange clusterIdRange = workbook.Worksheet(parameters.WorksheetName).Range(startReference + ":" + endReference);
        clusterIdRange.Row(1).Merge();
        clusterIdRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        clusterIdRange.SetValue(dataCluster.ClusterHeader);

        message = string.Empty;
        return true;
    }

    public override bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
    {
        message = string.Empty;
        return true;
    }
}
