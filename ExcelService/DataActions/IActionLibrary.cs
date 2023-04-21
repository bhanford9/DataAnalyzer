using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions
{
    public interface IActionLibrary
    {
        ICollection<string> GetCellActionDescriptions();
        ICollection<ActionInfo> GetCellActionInfo();
        ICollection<string> GetCellActionNames();
        ICollection<string> GetDataClusterActionDescriptions();
        ICollection<ActionInfo> GetDataClusterActionInfo();
        ICollection<string> GetDataClusterActionNames();
        ICollection<string> GetRowActionDescriptions();
        ICollection<ActionInfo> GetRowActionInfo();
        ICollection<string> GetRowActionNames();
        ICollection<string> GetWorkbookActionDescriptions();
        ICollection<ActionInfo> GetWorkbookActionInfo();
        ICollection<string> GetWorkbookActionNames();
        ICollection<string> GetWorksheetActionDescriptions();
        ICollection<ActionInfo> GetWorksheetActionInfo();
        ICollection<string> GetWorksheetActionNames();
    }
}