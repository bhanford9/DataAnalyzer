using DataAnalyzer.Common.Mvvm;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class LoadableRemovableRowViewModel : RowViewModel
  {
    private readonly BaseCommand remove;
    private readonly BaseCommand load;

    public LoadableRemovableRowViewModel()
    {
      this.remove = new BaseCommand((obj) => this.DoRemove());
      this.load = new BaseCommand((obj) => this.DoLoad());
    }

    public ICommand Remove => this.remove;
    public ICommand Load => this.load;

    private void DoRemove()
    {

    }

    private void DoLoad()
    {

    }
  }
}
