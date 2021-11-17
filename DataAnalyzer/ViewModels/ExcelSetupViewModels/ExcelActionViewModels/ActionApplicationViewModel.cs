using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ActionApplicationViewModel : BasePropertyChanged
  {
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
    private readonly EditActionLibrary editActionLibrary = BaseSingleton<EditActionLibrary>.Instance;

    private readonly IActionApplicationModel actionApplicationModel;

    private IEditActionViewModel currentAction;

    public ActionApplicationViewModel(
      ICollection<ExcelAction> actions,
      IActionApplicationModel actionApplicationModel)
    {
      this.actionApplicationModel = actionApplicationModel;

      actions.ToList().ForEach(action =>
      {
        this.Actions.Add(new ActionApplicationListItemViewModel(actionApplicationModel)
        {
          IsRemovable = false,
          Value = action.Name,
          ToolTipText = action.Description
        });
      });

      this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
      this.actionApplicationModel.PropertyChanged += this.ActionApplicationModelPropertyChanged;
    }

    public ObservableCollection<CheckableTreeViewItem> WhereToApply { get; }
      = new ObservableCollection<CheckableTreeViewItem>();

    public ObservableCollection<LoadableRemovableRowViewModel> Actions { get; }
      = new ObservableCollection<LoadableRemovableRowViewModel>();

    public IEditActionViewModel CurrentAction
    {
      get => this.currentAction;
      set => this.NotifyPropertyChanged(nameof(this.CurrentAction), ref this.currentAction, value);
    }

    private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.statsModel.HeirarchalStats):
          this.WhereToApply.Clear();
          this.WhereToApply.Add(new CheckableTreeViewItem() { Name = "All Workbooks", Path = string.Empty });

          this.actionApplicationModel.LoadWhereToApply(this.WhereToApply.First());
          break;
      }
    }

    private void ActionApplicationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.actionApplicationModel.LoadedActionName):
          ExcelAction action = this.actionApplicationModel.GetLoadedAction();
          this.CurrentAction = this.editActionLibrary.GetEditAction(action.ActionParameters);
          this.CurrentAction.ActionName = action.Name;
          this.CurrentAction.Description = action.Description;
          this.CurrentAction.ActionParameters = action.ActionParameters;
          break;
      }
    }
  }
}
