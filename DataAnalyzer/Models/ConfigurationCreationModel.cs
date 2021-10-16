using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
  public class ConfigurationCreationModel : BasePropertyChanged
  {
    private StatType selectedStatType = StatType.NotApplicable;

    private DataConfiguration dataConfiguration = new DataConfiguration();

    public StatType SelectedDataType
    {
      get => this.selectedStatType;
      set => this.NotifyPropertyChanged(nameof(this.SelectedDataType), ref this.selectedStatType, value);
    }

    public void CreateNewDataConfiguration()
    {
      this.dataConfiguration = new DataConfiguration();
    }
  }
}
