using ClosedXML.Excel;
using ExcelService.CellDataFormats;
using ExcelService.Cells;
using ExcelService.DataActions;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataClusters;
using ExcelService.Rows;
using ExcelService.Workbooks;
using System.Collections.Generic;
using System.Linq;

namespace ExcelService
{
  public class ExcelExecutive
  {
    private readonly ActionExecutive actionExecutive = new ActionExecutive();

    public void GenerateWorkbook(IWorkbook workbook)
    {
      IXLWorkbook closedXmlWorkbook = new XLWorkbook();

      workbook.Worksheets.ToList().ForEach(worksheet =>
      {
        IXLWorksheet closedXmlWorksheet = closedXmlWorkbook.Worksheets.Add(worksheet.SheetName);

        for (int clusterIndex = 0; clusterIndex < worksheet.DataClusters.Count; clusterIndex++)
        {
          IDataCluster dataCluster = worksheet.DataClusters.ElementAt(clusterIndex);
          int rowStartNumber = dataCluster.StartRowNumber;
          int colStartNumber = dataCluster.StartColNumber;

          if (dataCluster.UseClusterHeader)
          {
            if (clusterIndex == 0 && rowStartNumber == 1)
            {
              rowStartNumber++;
            }
            else if (clusterIndex > 0)
            {
              IDataCluster prevCluster = worksheet.DataClusters.ElementAt(clusterIndex - 1);
              int prevEndRowNumber = prevCluster.StartRowNumber + prevCluster.Rows.Count + 1;

              if (prevEndRowNumber >= rowStartNumber)
              {
                rowStartNumber = prevEndRowNumber + 2;
              }
            }

            dataCluster.HeaderRange = new Row(new List<ICell>() { new Cell(dataCluster.ClusterHeader, string.Empty, new TextCellDataFormat()) });
            dataCluster.HeaderRange.StartRowNumber = dataCluster.StartRowNumber - 1;
            dataCluster.HeaderRange.StartColNumber = dataCluster.StartColNumber;
            for (int i = 1; i < dataCluster.EndColNumber - 1; i++)
            {
              dataCluster.HeaderRange.Add(new Cell("", "", new TextCellDataFormat()));
            }

            DataCluster headerActionsDataCluster = new DataCluster(
              dataCluster.Rows,
              dataCluster.ClusterHeader,
              dataCluster.StartRowNumber - 1,
              dataCluster.StartColNumber - 1,
              dataCluster.Titles,
              new ActionDefinitions(dataCluster.ActionDefinitions
                .Where(x => x.Performer.Equals(ActionPerformer.DataClusterHeader))
                .ToList()),
              dataCluster.UseClusterHeader)
            {
              HeaderRange = dataCluster.HeaderRange
            };

            this.UpdateActionDefinitions(headerActionsDataCluster, worksheet.SheetName, ActionPerformer.DataClusterHeader);
            this.actionExecutive.PerformActions(closedXmlWorkbook, headerActionsDataCluster);
          }

          for (
            int rowNumber = rowStartNumber, rowIndex = 0;
            rowIndex < dataCluster.Rows.Count;
            rowNumber++, rowIndex++)
          {
            IRow row = dataCluster.Rows.ElementAt(rowIndex);
            row.StartRowNumber = rowNumber;
            row.StartColNumber = dataCluster.StartColNumber;

            for (
              int colNumber = colStartNumber, colIndex = 0;
              colIndex < row.Count;
              colNumber++, colIndex++)
            {
              ICell cell = row.ElementAt(colIndex);
              cell.StartRowNumber = rowNumber;
              cell.StartColNumber = colNumber;
              closedXmlWorksheet.Cell(rowNumber, colNumber).Style.NumberFormat.Format = cell.Format.GetFormatString();
              closedXmlWorksheet.Cell(rowNumber, colNumber).SetValue(cell.Value);

              this.UpdateActionDefinitions(cell, worksheet.SheetName, ActionPerformer.Cell);
              this.actionExecutive.PerformActions(closedXmlWorkbook, cell);
            }

            this.UpdateActionDefinitions(row, worksheet.SheetName, ActionPerformer.Row);
            this.actionExecutive.PerformActions(closedXmlWorkbook, row);
          }

          dataCluster = new DataCluster(
              dataCluster.Rows,
              dataCluster.ClusterHeader,
              dataCluster.StartRowNumber - 1,
              dataCluster.StartColNumber - 1,
              dataCluster.Titles,
              new ActionDefinitions(dataCluster.ActionDefinitions
                .Where(x => !x.Performer.Equals(ActionPerformer.DataClusterHeader))
                .ToList()),
              dataCluster.UseClusterHeader);

          this.UpdateActionDefinitions(dataCluster, worksheet.SheetName, ActionPerformer.DataCluster);
          this.actionExecutive.PerformActions(closedXmlWorkbook, dataCluster);
        };

        this.UpdateActionDefinitions(worksheet, worksheet.SheetName, ActionPerformer.Worksheet);
        this.actionExecutive.PerformActions(closedXmlWorkbook, worksheet);
      });

      closedXmlWorkbook.SaveAs(workbook.FilePath);

      this.actionExecutive.PerformActions(closedXmlWorkbook, workbook);
    }

    public void GenerateWorkbooks(ICollection<IWorkbook> workbooks)
    {

    }

    private void UpdateActionDefinitions(IExcelEntity excelEntity, string worksheetName, ActionPerformer performer)
    {
      foreach (IActionParameters actionDefinition in excelEntity.ActionDefinitions)
      {
        actionDefinition.WorksheetName = worksheetName;
        actionDefinition.Performer = performer;
      }
    }
  }
}
