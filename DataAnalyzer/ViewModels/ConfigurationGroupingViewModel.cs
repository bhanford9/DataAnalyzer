using DataAnalyzer.Common.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
  public class ConfigurationGroupingViewModel : BasePropertyChanged
  {
    private string name = string.Empty;

    private BaseCommand addProperty;

    public ConfigurationGroupingViewModel()
    {
      this.addProperty = new BaseCommand((obj) => this.DoAddProperty());
    }

    public ICommand AddProperty => this.addProperty;

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }

    private void DoAddProperty()
    {

    }
  }
}
