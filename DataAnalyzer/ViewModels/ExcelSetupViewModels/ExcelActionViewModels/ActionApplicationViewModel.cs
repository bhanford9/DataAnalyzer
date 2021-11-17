using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
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

    private readonly IActionApplicationModel actionApplicationModel;

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
    }

    public ObservableCollection<CheckableTreeViewItem> WorkbookNames { get; }
      = new ObservableCollection<CheckableTreeViewItem>();

    public ObservableCollection<LoadableRemovableRowViewModel> Actions { get; }
      = new ObservableCollection<LoadableRemovableRowViewModel>();

    private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.statsModel.HeirarchalStats):
          this.WorkbookNames.Clear();
          this.WorkbookNames.Add(new CheckableTreeViewItem() { Name = "All Workbooks", Path = string.Empty });

          foreach (HeirarchalStats stats in this.statsModel.HeirarchalStats.Children)
          {
            this.WorkbookNames.First().Children.Add(new CheckableTreeViewItem()
            {
              Name = stats.Key.ToString(),
              Path = stats.Key.ToString()
            });
          }
          break;
      }
    }
  }
}
