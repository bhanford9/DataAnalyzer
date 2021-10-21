using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
  public class ConfigurationGroupingViewModel : BasePropertyChanged
  {
    private readonly ConfigurationCreationModel configurationCreationModel = BaseSingleton<ConfigurationCreationModel>.Instance;

    private readonly int index = 0;
    private string name = string.Empty;
    private string selectedParameter = string.Empty;
    private ICollection<string> parameterNames = new List<string>();

    private readonly BaseCommand addParameter;

    public ConfigurationGroupingViewModel(int index)
    {
      this.index = index;

      this.addParameter = new BaseCommand((obj) => this.DoAddParameter());

      this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;

      this.LoadParameters();
    }

    public ICommand AddParameter => this.addParameter;

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }

    public string SelectedParameter
    {
      get => this.selectedParameter;
      set => this.NotifyPropertyChanged(nameof(this.SelectedParameter), ref this.selectedParameter, value);
    }

    public string GroupByText => this.index == 0 ? "Group By:" : "Then By:";

    public ICollection<string> ParameterNames
    {
      get => this.parameterNames;
      set => this.NotifyPropertyChanged(nameof(this.ParameterNames), ref this.parameterNames, value);
    }

    private void DoAddParameter()
    {

    }

    private void LoadParameters()
    {
      if (this.configurationCreationModel.DataParameterCollection != null)
      {
        this.ParameterNames = this.configurationCreationModel.DataParameterCollection.GetParameters()
          .Where(x => x.CanGroupBy)
          .Select(x => x.Name)
          .ToList();
      }
    }

    private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationCreationModel.DataParameterCollection):
          this.LoadParameters();
          break;
        default:
          break;
      }
    }
  }
}
