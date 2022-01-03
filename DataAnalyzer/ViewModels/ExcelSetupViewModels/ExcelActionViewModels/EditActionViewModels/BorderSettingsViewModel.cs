using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class BorderSettingsViewModel : BasePropertyChanged
  {
    private string selectedStyle = string.Empty;
    private string borderName = string.Empty;

    private readonly EnumUtilities EnumUtilities = new EnumUtilities();

    public BorderSettingsViewModel()
    {
      this.EnumUtilities.LoadNames(typeof(BorderStyle), this.BorderStyles);
    }

    public ObservableCollection<string> BorderStyles { get; }
      = new ObservableCollection<string>();

    public ColorsComboBoxViewModel ComboBoxColors { get; }
      = new ColorsComboBoxViewModel();

    public string SelectedStyle
    {
      get => this.selectedStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedStyle), ref this.selectedStyle, value);
    }

    public string BorderName
    {
      get => this.borderName;
      set => this.NotifyPropertyChanged(nameof(this.BorderName), ref this.borderName, value);
    }
  }
}
