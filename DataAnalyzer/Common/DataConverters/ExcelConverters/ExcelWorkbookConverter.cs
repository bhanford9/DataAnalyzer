﻿using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using ExcelService.Cells;
using ExcelService.DataClusters;
using ExcelService.Rows;
using ExcelService.Workbooks;
using ExcelService.Worksheets;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
  public class ExcelWorkbookConverter
  {
    public static IWorkbook WorkbookModelToExcelWorkbook(WorkbookModel workbookModel)
    {
      StandardWorkbook standardWorkbook = new StandardWorkbook(
        workbookModel.FilePath,
        workbookModel.Worksheets.Select(x => WorksheetModelToExcelWorksheet(x)).ToList(),
        ExcelActionConverter.ToExcelDefinitions(workbookModel.WorkbookActions.Select(x => x.ActionParameters).ToList()));

      return standardWorkbook;
    }

    public static IWorksheet WorksheetModelToExcelWorksheet(WorksheetModel worksheetModel)
    {
      Worksheet worksheet = new Worksheet(
        worksheetModel.WorksheetName,
        worksheetModel.DataClusters.Select(x => DataClusterModelToExcelDataCluster(x)).ToList(),
        ExcelActionConverter.ToExcelDefinitions(worksheetModel.WorksheetActions.Select(x => x.ActionParameters).ToList()));

      return worksheet;
    }

    public static IDataCluster DataClusterModelToExcelDataCluster(DataClusterModel dataClusterModel)
    {
      DataCluster dataCluster = new DataCluster(
        dataClusterModel.Rows.Select(x => RowModelToExcelRow(x)).ToList(),
        dataClusterModel.Name,
        dataClusterModel.StartRowIndex,
        dataClusterModel.StartColIndex,
        true,  // generates titels
        ExcelActionConverter.ToExcelDefinitions(dataClusterModel.DataClusterActions.Select(x => x.ActionParameters).ToList()),
        true); // uses cluster id

      return dataCluster;
    }

    public static IRow RowModelToExcelRow(RowModel rowModel)
    {
      ICollection<ICell> cells = new List<ICell>();
      for (int i = 0; i < rowModel.Cells.Count; i++)
      {
        cells.Add(CellModelToExcelCell(rowModel.Cells.ElementAt(i), i));
      }

      return new Row(
        cells,
        ExcelActionConverter.ToExcelDefinitions(rowModel.RowActions.Select(x => x.ActionParameters).ToList()));
    }

    public static ICell CellModelToExcelCell(CellModel cellModel, int rowIndex)
    {
      return new Cell(
        cellModel.Value,
        rowIndex,
        cellModel.DataType.CreateCellDataFormat(),
        ExcelActionConverter.ToExcelDefinitions(cellModel.CellActions.Select(x => x.ActionParameters).ToList()));
    }
  }
}