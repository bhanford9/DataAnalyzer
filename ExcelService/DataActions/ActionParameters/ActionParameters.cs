namespace ExcelService.DataActions.ActionParameters;

public abstract class ActionParameters : IActionParameters
{
    public abstract string Name { get; }

    public string WorksheetName { get; set; } = string.Empty;

    public virtual ActionPerformer Performer { get; set; } = ActionPerformer.Unassigned;

    public abstract ActionCategory Category { get; }
}
