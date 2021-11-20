using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ExcelDataTypesViewModel : BasePropertyChanged
  {
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
    private readonly ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;

    public ExcelDataTypesViewModel()
    {
      excelDataTypeLibrary.GetParameterTypes().ToList().ForEach(x => this.ParameterTypes.Add(x));
      this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
    }

    public ObservableCollection<ITypeParameter> ParameterTypes { get; }
      = new ObservableCollection<ITypeParameter>();

    public ObservableCollection<DataTypeSelectionViewModel> ParameterSelections { get; }
      = new ObservableCollection<DataTypeSelectionViewModel>();

    private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.statsModel.StatNames):
          foreach (string name in this.statsModel.StatNames)
          {
            this.ParameterSelections.Add(new DataTypeSelectionViewModel()
            {
              DataName = name,
              // TODO --> come up with a way of knowing the default or read from config
              //SelectedParameterType = 
            });
          }
          break;
      }
    }
  }
}
