using ExcelService.DataActions.ActionParameters;

namespace ExcelService
{
  public class ExcelEntity : IExcelEntity
  {
    public virtual string Name { get; } = "Generic Excel Entity";

    public IActionDefinitions ActionDefinitions { get; protected set; } = new ActionDefinitions();
  }
}
