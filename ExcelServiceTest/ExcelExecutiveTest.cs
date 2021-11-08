using ExcelService;
using ExcelService.DataActions.ActionParameters;
using ExcelService.CellDataFormats;
using ExcelService.CellDataFormats.NumericFormat;
using ExcelService.Cells;
using ExcelService.DataClusters;
using ExcelService.Rows;
using ExcelService.Workbooks;
using ExcelService.Worksheets;
using System.Collections.Generic;
using Xunit;
using ExcelService.DataActions.ActionParameters.WorkbookParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.Styles.Colors;
using ExcelService.Styles.Borders;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;

namespace ExcelServiceTest
{
  public class ExcelExecutiveTest
  {
    [Fact]
    public void Test1()
    {
      ExcelExecutive excelExecutive = new ExcelExecutive();

      ICollection<ICell> adamData = new List<ICell>
      {
        new Cell(0, "Id", new GeneralNumericCellDataFormat()),
        new Cell("Adam", "Name", new TextCellDataFormat()),
        new Cell(26, "Age", new GeneralNumericCellDataFormat()),
        new Cell(190, "Weight", new GeneralNumericCellDataFormat())
      };

      ICollection<ICell> aliceData = new List<ICell>
      {
        new Cell(1, "Id", new GeneralNumericCellDataFormat()),
        new Cell("Alice", "Name", new TextCellDataFormat()),
        new Cell(27, "Age", new GeneralNumericCellDataFormat()),
        new Cell(150, "Weight", new GeneralNumericCellDataFormat())
      };

      Row adamRow = new Row(adamData);
      Row aliceRow = new Row(aliceData);

      ICollection<IRow> rows = new List<IRow>()
      {
        adamRow,
        aliceRow
      };

      ActionDefinitions clusterActions = new ActionDefinitions()
      {
        new HeaderMergeCenterFullParameters(),
        new HeaderBorderStyleParameters()
        {
          AllBorders = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin }
        },
        new HeaderBackgroundStyleParameters() { Color = new ColorValue(Color.LightGray) },
        new BorderStyleParameters()
        {
          Left = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin },
          Top = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin },
          Right = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin },
          Bottom = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin }
        },
        new ColumnBorderStyleParameters()
        {
          Border = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin }
        },
        new NthRowBorderStyleParameters()
        {
          NthRow = 0,
          AllBorders = new Border() { Color = new ColorValue(Color.Black), Style = BorderStyle.Thin }
        }
      };

      DataCluster dataCluster1 = new DataCluster(rows, "First Cluster", 1, 1, true, clusterActions);
      DataCluster dataCluster2 = new DataCluster(rows, "Second Cluster", dataCluster1.Rows.Count + 4, 1, true, clusterActions);

      ICollection<IDataCluster> dataClusters = new List<IDataCluster>()
      {
        dataCluster1,
        dataCluster2
      };

      Worksheet worksheet = new Worksheet("MyFirstWorksheet", dataClusters);

      ICollection<IWorksheet> worksheets = new List<IWorksheet>()
      {
        worksheet
      };


      IActionDefinitions actionParameters = new ActionDefinitions();
      actionParameters.Add(new DisplayWorkbookParameters());

      StandardWorkbook workbook = new StandardWorkbook(
        @"C:\Users\bmhanford\Documents\ExcelExecutiveTest\MyFirstWorkbook.xlsx",
        worksheets,
        actionParameters);

      excelExecutive.GenerateWorkbook(workbook);
    }
  }
}
