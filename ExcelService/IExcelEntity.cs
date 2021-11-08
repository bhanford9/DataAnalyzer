using ExcelService.DataActions.ActionParameters;

namespace ExcelService
{
  public interface IExcelEntity
  {
    IActionDefinitions ActionDefinitions { get; }
    string Name { get; }
  }
}
