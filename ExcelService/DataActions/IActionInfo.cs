using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions;

public interface IActionInfo
{
    IActionParameters DefaultParameters { get; }
    string Description { get; }
    string Name { get; }
}