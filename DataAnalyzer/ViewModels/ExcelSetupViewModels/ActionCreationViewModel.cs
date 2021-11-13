using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ActionCreationViewModel : BasePropertyChanged
  {
    private BaseCommand createAction;

    public ActionCreationViewModel(ICollection<ExcelAction> actions)
    {
      actions.ToList().ForEach(action => this.Actions.Add(new ActionListItemViewModel()
      {
        IsRemovable = !action.IsBuiltIn,
        Value = action.Name,
        ToolTipText = action.Description
      }));

      this.createAction = new BaseCommand((obj) => this.DoCreateAction());
    }

    public ObservableCollection<LoadableRemovableRowViewModel> Actions { get; }
      = new ObservableCollection<LoadableRemovableRowViewModel>();

    public ICommand CreateAction => this.createAction;

    private void DoCreateAction()
    {

    }
  }
}
