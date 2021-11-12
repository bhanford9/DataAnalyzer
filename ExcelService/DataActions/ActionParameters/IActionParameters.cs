namespace ExcelService.DataActions.ActionParameters
{
  public interface IActionParameters
  {
    string Name { get; }
    string WorksheetName { get; set; }
    ActionPerformer Performer { get; set; }
    ActionCategory Category { get; }
  }
}
