using DataAnalyzer.Common.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reflection;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class ColorsComboBoxViewModel : BasePropertyChanged
  {
    private string selectedColor;

    public ColorsComboBoxViewModel()
    {
      foreach (PropertyInfo info in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public))
      {
        this.Colors.Add(info.Name);
      }
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
