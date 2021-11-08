using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ClusterActions;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataActions.WorkbookActions;
using System.Collections.Generic;
using System.Linq;

namespace ExcelService.DataActions
{
  public class ActionLibrary
  {
    private readonly ICollection<IDataAction> workbookActions = new List<IDataAction>();
    private readonly ICollection<IDataAction> worksheetActions = new List<IDataAction>();
    private readonly ICollection<IDataAction> dataClusterActions = new List<IDataAction>();
    private readonly ICollection<IDataAction> rowActions = new List<IDataAction>();
    private readonly ICollection<IDataAction> cellActions = new List<IDataAction>();

    public ActionLibrary()
    {
      this.RegisterWorkbookActions();
      this.RegisterWorksheetActions();
      this.RegisterDataClusterActions();
      this.RegisterRowActions();
      this.RegisterCellActions();
    }

    public ICollection<string> GetWorkbookActionNames()
    {
      return this.GetActionNames(this.workbookActions);
    }

    public ICollection<string> GetWorksheetActionNames()
    {
      return this.GetActionNames(this.worksheetActions);
    }

    public ICollection<string> GetDataClusterActionNames()
    {
      return this.GetActionNames(this.dataClusterActions);
    }

    public ICollection<string> GetRowActionNames()
    {
      return this.GetActionNames(this.rowActions);
    }

    public ICollection<string> GetCellActionNames()
    {
      return this.GetActionNames(this.cellActions);
    }

    public ICollection<string> GetWorkbookActionDescriptions()
    {
      return this.GetActionDescriptions(this.workbookActions);
    }

    public ICollection<string> GetWorksheetActionDescriptions()
    {
      return this.GetActionDescriptions(this.worksheetActions);
    }

    public ICollection<string> GetDataClusterActionDescriptions()
    {
      return this.GetActionDescriptions(this.dataClusterActions);
    }

    public ICollection<string> GetRowActionDescriptions()
    {
      return this.GetActionDescriptions(this.rowActions);
    }

    public ICollection<string> GetCellActionDescriptions()
    {
      return this.GetActionDescriptions(this.cellActions);
    }

    public ICollection<ActionInfo> GetWorkbookActionInfo()
    {
      return this.GetActionInfo(this.workbookActions);
    }

    public ICollection<ActionInfo> GetWorksheetActionInfo()
    {
      return this.GetActionInfo(this.worksheetActions);
    }

    public ICollection<ActionInfo> GetDataClusterActionInfo()
    {
      return this.GetActionInfo(this.dataClusterActions);
    }

    public ICollection<ActionInfo> GetRowActionInfo()
    {
      return this.GetActionInfo(this.rowActions);
    }

    public ICollection<ActionInfo> GetCellActionInfo()
    {
      return this.GetActionInfo(this.cellActions);
    }

    internal IDataAction GetWorkbookAction(string name)
    {
      return this.GetAction(this.workbookActions, name);
    }

    internal IDataAction GetWorksheetAction(string name)
    {
      return this.GetAction(this.worksheetActions, name);
    }

    internal IDataAction GetDataClusterAction(string name)
    {
      return this.GetAction(this.dataClusterActions, name);
    }

    internal IDataAction GetRowAction(string name)
    {
      return this.GetAction(this.rowActions, name);
    }

    internal IDataAction GetCellAction(string name)
    {
      return this.GetAction(this.cellActions, name);
    }

    internal IDataAction GetWorkbookAction(IActionParameters parameters)
    {
      return this.GetAction(this.workbookActions, parameters);
    }

    internal IDataAction GetWorksheetAction(IActionParameters parameters)
    {
      return this.GetAction(this.worksheetActions, parameters);
    }

    internal IDataAction GetDataClusterAction(IActionParameters parameters)
    {
      return this.GetAction(this.dataClusterActions, parameters);
    }

    internal IDataAction GetRowAction(IActionParameters parameters)
    {
      return this.GetAction(this.rowActions, parameters);
    }

    internal IDataAction GetCellAction(IActionParameters parameters)
    {
      return this.GetAction(this.cellActions, parameters);
    }

    internal IDataAction GetAction(string name)
    {
      IDataAction dataAction = this.GetWorkbookAction(name);

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

    internal IDataAction GetAction(IActionParameters parameters)
    {
      IDataAction dataAction = this.GetWorkbookAction(parameters);

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

    private ICollection<string> GetActionNames(ICollection<IDataAction> subLibrary)
    {
      return subLibrary.Select(x => x.GetName()).ToList();
    }

    private ICollection<string> GetActionDescriptions(ICollection<IDataAction> subLibrary)
    {
      return subLibrary.Select(x => x.GetDescription()).ToList();
    }

    private ICollection<ActionInfo> GetActionInfo(ICollection<IDataAction> subLibrary)
    {
      return subLibrary.Select(x => new ActionInfo() { Name = x.GetName(), Description = x.GetDescription() }).ToList();
    }

    private IDataAction GetAction(ICollection<IDataAction> subLibrary, string name)
    {
      return subLibrary.ToList().FirstOrDefault(x => x.GetName().Equals(name));
    }

    private IDataAction GetAction(ICollection<IDataAction> subLibrary, IActionParameters parameters)
    {
      return subLibrary.ToList().FirstOrDefault(x => x.IsApplicable(parameters));
    }

    private void RegisterWorkbookActions()
    {
      this.workbookActions.Add(new DisplayWorkbookAction());
    }

    private void RegisterWorksheetActions()
    {

    }

    private void RegisterDataClusterActions()
    {
      this.dataClusterActions.Add(new HeaderBorderStyleAction());
      this.dataClusterActions.Add(new HeaderMergeCenterFullAction());
      this.dataClusterActions.Add(new HeaderBackgroundStyleAction());

      this.dataClusterActions.Add(new BorderStyleAction());
      this.dataClusterActions.Add(new BackgroundStyleAction());
      this.dataClusterActions.Add(new ColumnBorderStyleAction());
      this.dataClusterActions.Add(new NthRowBorderStyleAction());
    }

    private void RegisterRowActions()
    {
      this.rowActions.Add(new BorderStyleAction());
      this.rowActions.Add(new BackgroundStyleAction());
      this.rowActions.Add(new ColumnBorderStyleAction());
    }

    private void RegisterCellActions()
    {
      this.cellActions.Add(new BorderStyleAction());
      this.cellActions.Add(new BackgroundStyleAction());
    }
  }
}
