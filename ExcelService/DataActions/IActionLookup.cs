using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions;

internal interface IActionLookup
{
    IDataAction? GetAction(IActionParameters parameters);
    IDataAction? GetAction(string name);
    IDataAction? GetCellAction(IActionParameters parameters);
    IDataAction? GetCellAction(string name);
    IDataAction? GetDataClusterAction(IActionParameters parameters);
    IDataAction? GetDataClusterAction(string name);
    IDataAction? GetRowAction(IActionParameters parameters);
    IDataAction? GetRowAction(string name);
    IDataAction? GetWorkbookAction(IActionParameters parameters);
    IDataAction? GetWorkbookAction(string name);
    IDataAction? GetWorksheetAction(IActionParameters parameters);
    IDataAction? GetWorksheetAction(string name);
}
