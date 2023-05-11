using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions;

public class ActionLibrary : IInternalActionLibrary
{
    private readonly IReadOnlyCollection<IDataAction> workbookActions;
    private readonly IReadOnlyCollection<IDataAction> worksheetActions;
    private readonly IReadOnlyCollection<IDataAction> dataClusterActions;
    private readonly IReadOnlyCollection<IDataAction> rowActions;
    private readonly IReadOnlyCollection<IDataAction> cellActions;

    public ActionLibrary(
        IReadOnlyCollection<IDataAction> workbookActions,
        IReadOnlyCollection<IDataAction> worksheetActions,
        IReadOnlyCollection<IDataAction> dataClusterActions,
        IReadOnlyCollection<IDataAction> rowActions,
        IReadOnlyCollection<IDataAction> cellActions)
    {
        this.workbookActions = workbookActions;
        this.worksheetActions = worksheetActions;
        this.dataClusterActions = dataClusterActions;
        this.rowActions = rowActions;
        this.cellActions = cellActions;
    }

    public ICollection<string> GetWorkbookActionNames() => this.GetActionNames(this.workbookActions);

    public ICollection<string> GetWorksheetActionNames() => this.GetActionNames(this.worksheetActions);

    public ICollection<string> GetDataClusterActionNames() => this.GetActionNames(this.dataClusterActions);

    public ICollection<string> GetRowActionNames() => this.GetActionNames(this.rowActions);

    public ICollection<string> GetCellActionNames() => this.GetActionNames(this.cellActions);

    public ICollection<string> GetWorkbookActionDescriptions() =>
        this.GetActionDescriptions(this.workbookActions);

    public ICollection<string> GetWorksheetActionDescriptions() =>
        this.GetActionDescriptions(this.worksheetActions);

    public ICollection<string> GetDataClusterActionDescriptions() =>
        this.GetActionDescriptions(this.dataClusterActions);

    public ICollection<string> GetRowActionDescriptions() => this.GetActionDescriptions(this.rowActions);

    public ICollection<string> GetCellActionDescriptions() => this.GetActionDescriptions(this.cellActions);

    public ICollection<ActionInfo> GetWorkbookActionInfo() => this.GetActionInfo(this.workbookActions);

    public ICollection<ActionInfo> GetWorksheetActionInfo() => this.GetActionInfo(this.worksheetActions);

    public ICollection<ActionInfo> GetDataClusterActionInfo() => this.GetActionInfo(this.dataClusterActions);

    public ICollection<ActionInfo> GetRowActionInfo() => this.GetActionInfo(this.rowActions);

    public ICollection<ActionInfo> GetCellActionInfo() => this.GetActionInfo(this.cellActions);

    public IDataAction? GetWorkbookAction(string name) => this.GetAction(this.workbookActions, name);

    public IDataAction? GetWorksheetAction(string name) => this.GetAction(this.worksheetActions, name);

    public IDataAction? GetDataClusterAction(string name) => this.GetAction(this.dataClusterActions, name);

    public IDataAction? GetRowAction(string name) => this.GetAction(this.rowActions, name);

    public IDataAction? GetCellAction(string name) => this.GetAction(this.cellActions, name);

    public IDataAction? GetWorkbookAction(IActionParameters parameters) =>
        this.GetAction(this.workbookActions, parameters);

    public IDataAction? GetWorksheetAction(IActionParameters parameters) =>
        this.GetAction(this.worksheetActions, parameters);

    public IDataAction? GetDataClusterAction(IActionParameters parameters) =>
        this.GetAction(this.dataClusterActions, parameters);

    public IDataAction? GetRowAction(IActionParameters parameters) =>
        this.GetAction(this.rowActions, parameters);

    public IDataAction? GetCellAction(IActionParameters parameters) =>
        this.GetAction(this.cellActions, parameters);

    public IDataAction? GetAction(string name)
    {
        IDataAction? dataAction = this.GetWorkbookAction(name);

        if (dataAction == default)
        {
            dataAction = this.GetWorksheetAction(name);

            if (dataAction == default)
            {
                dataAction = this.GetDataClusterAction(name);

                if (dataAction == default)
                {
                    dataAction = this.GetRowAction(name);

                    if (dataAction == default)
                    {
                        dataAction = this.GetCellAction(name);
                    }
                }
            }
        }

        return dataAction;
    }

    public IDataAction? GetAction(IActionParameters parameters)
        => parameters.Performer switch
        {
            ActionPerformer.Workbook => this.GetWorkbookAction(parameters),
            ActionPerformer.Worksheet => this.GetWorksheetAction(parameters),
            ActionPerformer.DataCluster or ActionPerformer.DataClusterHeader => this.GetDataClusterAction(parameters),
            ActionPerformer.Row => this.GetRowAction(parameters),
            ActionPerformer.Cell => this.GetCellAction(parameters),
            _ => this.SearchAction(parameters),
        };

    private IDataAction? SearchAction(IActionParameters parameters)
    {
        IDataAction? dataAction = this.GetWorkbookAction(parameters);

        if (dataAction == default)
        {
            dataAction = this.GetWorksheetAction(parameters);

            if (dataAction == default)
            {
                dataAction = this.GetDataClusterAction(parameters);

                if (dataAction == default)
                {
                    dataAction = this.GetRowAction(parameters);

                    if (dataAction == default)
                    {
                        dataAction = this.GetCellAction(parameters);
                    }
                }
            }
        }

        return dataAction;
    }

    private ICollection<string> GetActionNames(IReadOnlyCollection<IDataAction> subLibrary) =>
        subLibrary.Select(x => x.GetName()).ToList();

    private ICollection<string> GetActionDescriptions(IReadOnlyCollection<IDataAction> subLibrary) =>
        subLibrary.Select(x => x.GetDescription()).ToList();

    private ICollection<ActionInfo> GetActionInfo(IReadOnlyCollection<IDataAction> subLibrary) => subLibrary
          .Select(x => new ActionInfo
          {
              Name = x.GetName(),
              Description = x.GetDescription(),
              DefaultParameters = x.GetDefaultParameters()
          })
          .ToList();

    private IDataAction? GetAction(IReadOnlyCollection<IDataAction> subLibrary, string name) =>
        subLibrary.ToList().FirstOrDefault(x => x.GetName().Equals(name));

    private IDataAction? GetAction(IReadOnlyCollection<IDataAction> subLibrary, IActionParameters parameters) =>
        subLibrary.ToList().FirstOrDefault(x => x.IsApplicable(parameters));
}
