using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class ColorsComboBoxViewModel : BasePropertyChanged
  {
    private string selectedColor;

    public ColorsComboBoxViewModel()
    {
      typeof(Color)
        .GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
        .OrderBy(info => Color.FromName(info.Name).GetHue())
        .ThenBy(info => Color.FromName(info.Name).R * 3 + Color.FromName(info.Name).G * 2 + Color.FromName(info.Name).B)
        .ToList()
        .ForEach(info => this.Colors.Add(info.Name));
    }

    public ObservableCollection<string> Colors { get; }
      = new ObservableCollection<string>();

    public string SelectedColor
    {
      get => this.selectedColor;
      set => this.NotifyPropertyChanged(nameof(this.SelectedColor), ref this.selectedColor, value);
    }
  }
}
