using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ActionApplicationViewModel : BasePropertyChanged
  {
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
    private readonly EditActionLibrary editActionLibrary = BaseSingleton<EditActionLibrary>.Instance;

    private readonly IActionApplicationModel actionApplicationModel;

    private IEditActionViewModel currentAction;

    private readonly BaseCommand applyAction;

    public ActionApplicationViewModel(
      ICollection<ExcelAction> actions,
      IActionApplicationModel actionApplicationModel)
    {
      this.actionApplicationModel = actionApplicationModel;

      this.applyAction = new BaseCommand((obj) => this.DoApplyAction());

      EmptyParameters empty = new EmptyParameters();
      this.currentAction = this.editActionLibrary.GetEditAction(new EmptyParameters());
      this.currentAction.ActionParameters = empty;

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

    public ICommand ApplyAction => this.applyAction;

    public IEditActionViewModel CurrentAction
    {
      get => this.currentAction;
      set => this.NotifyPropertyChanged(nameof(this.CurrentAction), ref this.currentAction, value);
    }

    private ICollection<CheckableTreeViewItem> GetFlattenedWhereToApply()
    {
      ICollection<CheckableTreeViewItem> flattenedItems = new List<CheckableTreeViewItem>();
      this.LoadIntoFlattened(this.WhereToApply.First(), flattenedItems);
      return flattenedItems;
    }

    private void LoadIntoFlattened(CheckableTreeViewItem baseItem, ICollection<CheckableTreeViewItem> flattened)
    {
      foreach (CheckableTreeViewItem child in baseItem.Children)
      {
        if (child.Children != null && child.Children.Count > 0)
        {
          this.LoadIntoFlattened(child, flattened);
        }

        flattened.Add(child);
      }

      flattened.Add(baseItem);
    }

    private void DoApplyAction()
    {
      this.GetFlattenedWhereToApply()
        .Where(x => x.IsChecked && x.IsLeaf)
        .ToList()
        .ForEach(treeViewItem =>
        {
          // tell Model to apply "CurrentAction" to "treeViewItem"
          CheckableTreeViewItem blah = new CheckableTreeViewItem()
          {
            //Children = new ObservableCollection<CheckableTreeViewItem>(),
            IsChecked = false,
            IsLeaf = false,
            Name = string.Empty,
            Path = string.Empty
          };

          IEditActionViewModel viewModel = new AlignmentEditViewModel();

          // model side may benefit from something like IDictionary<string, object>
          //   where the key is the path (always unique)
          //   where the value is a converted data object associated with it (not simply IEditActionViewModel, maybe the serializable equivalent)






          // summary side:
          //   1. create tree heirarchy based on saved items (Will be a small subset of all possibilities)
          //   2. make this into a serializable data structure for saving

          // execution side:
          //   1. convert into excel service action execution heirarchy

          // startup side:
          //   2. convert out of serialization into model data and model data into view model data


          // View Model <--> Serializable (Model) <--> Excel

          // Excel takes heirarchy of 
          //   Workbook
          //     Name
          //     Actions
          //     Worksheets
          //       [0]Name
          //       [0]Actions
          //       [0]DataClusters

          // Application View Model contains separate entities for each of
          //   Workbook
          //   Worksheet
          //   Data Cluster

          // Easiest thing to do might be to just have an overarching Summary Model that contains
          //   the serialized version of the entire thing that can easily be polled & converted
          //   up to the View Model or down to the Excel Service
          //
          // The Aciton Parameters are already setup as Custom Serializables
          //
          // Excel workbook is created with:
          //   File Path
          //   List<Worksheets>
          //   Acitons
          // Excel Worksheet is created with:
          //   Name
          //   List<DataClusters>
          //   Actions
          // Excel Data Cluster is created with:
          //   ICollection<IRow>
          //   string clusterHeader
          //   int startRowIndex
          //   int startColIndex
          //   IRow titles
          //   IActionDefinitions clusterActions = null
          //   bool useClusterId = true
        });
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
