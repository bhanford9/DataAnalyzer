using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataClusters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.Utilities;
using System.Linq;

namespace ExcelService.DataActions.ClusterActions
{
    internal class ClusterColumnBourderStyleAction : BorderStyleAction
    {
        public override string GetName()
        {
            return "Cluster Column Border Style";
        }

        public override string GetDescription()
        {
            return "Sets the color and style of the Border(s) for a Data Cluster's Column";
        }

        public override IActionParameters GetDefaultParameters()
        {
            return new ColumnBorderStyleParameters();
        }

        public override bool IsApplicable(IActionParameters parameters)
        {
            return this.IsCorrectType(parameters, typeof(ColumnBorderStyleParameters)) &&
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
            ColumnBorderStyleParameters borderStyleParameters = parameters as ColumnBorderStyleParameters;
            IDataCluster dataCluster = excelEntity as IDataCluster;

            if (borderStyleParameters.ColumnSpecification.UseNthColumn)
            {
                // TODO --> check if col number is zero or one indexed
                if (dataCluster.EndColNumber < borderStyleParameters.ColumnSpecification.NthColumn)
                {
                    message = $"Cannot assign border style to {borderStyleParameters.ColumnSpecification.NthColumn}. " +
                      $"The last column number in the data range is column {dataCluster.EndColNumber}.";
                    return false;
                }

                // TODO
            }
            else if (borderStyleParameters.ColumnSpecification.UseColumnAddress)
            {
                int specColNumber = ColumnConversions.NameToNumber(borderStyleParameters.ColumnSpecification.ColumnAddress);
                // TODO
            }
            else if (borderStyleParameters.ColumnSpecification.UseColumnHeader)
            {
                int specColNumber = dataCluster.Titles
                    .Select(x => x.Value.ToString())
                    .ToList()
                    .IndexOf(borderStyleParameters.ColumnSpecification.ColumnHeader);
                // TODO
            }

            // TODO
            message = string.Empty;
            return true;
        }
    }
}
