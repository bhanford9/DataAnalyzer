using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ActionsSummaryViewModel : BasePropertyChanged
  {
    // Stats model probably isn't the right way to do this. Instead...
    //   1. The Application side ViewModel should push down to its Model
    //   2. The Summary side Model should react to those changes and update itself
    //   3. The Summary side View Model should react to its Model's changes
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
    private IActionsSummaryModel actionsSummaryModel;

    private string configName = string.Empty;

    private BaseCommand saveConfiguration;

    public ActionsSummaryViewModel(IActionsSummaryModel actionsSummaryModel)
    {
      this.actionsSummaryModel = actionsSummaryModel;

      this.saveConfiguration = new BaseCommand((obj) => this.DoSaveConfiguration());

      this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
    }

    public ObservableCollection<ActionSummaryTreeViewItem> HeirarchicalSummaries { get; }
      = new ObservableCollection<ActionSummaryTreeViewItem>();

    public ICommand SaveConfiguration => this.saveConfiguration;

    public string ConfigName
    {
      get => this.configName;
      set => this.NotifyPropertyChanged(nameof(this.ConfigName), ref this.configName, value);
    }

    private void DoSaveConfiguration()
    {

    }

    private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.statsModel.HeirarchalStats):
          this.HeirarchicalSummaries.Clear();
          this.HeirarchicalSummaries.Add(new ActionSummaryTreeViewItem() { Name = "All Workbooks" });

          this.actionsSummaryModel.LoadHeirarchicalSummaries(this.HeirarchicalSummaries.First());
          break;
      }
    }
  }
}
