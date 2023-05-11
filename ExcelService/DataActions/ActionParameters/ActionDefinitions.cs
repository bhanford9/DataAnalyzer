namespace ExcelService.DataActions.ActionParameters;

public class ActionDefinitions : List<IActionParameters>, IActionDefinitions
{
    public ActionDefinitions() { }

    public ActionDefinitions(ICollection<IActionParameters> actionParameters)
    {
        this.AddRange(actionParameters);
    }
}
