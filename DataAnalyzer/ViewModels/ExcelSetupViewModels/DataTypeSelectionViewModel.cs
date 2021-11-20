using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;
using System;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class DataTypeSelectionViewModel : BasePropertyChanged
  {
    private string dataName = string.Empty;
    private ITypeParameter selectedParameterType;

    private string parameter1Name = string.Empty;
    private string parameter2Name = string.Empty;

    private string parameter1Value = string.Empty;
    private string parameter2Value = string.Empty;

    private Action<ITypeParameter, string> setParam1;
    private Action<ITypeParameter, string> setParam2;

    public DataTypeSelectionViewModel()
    {
      this.SelectedParameterType = new NoTypeParameter(
        new GeneralNumericCellDataFormat(),
        (param) => new GeneralNumericCellDataFormat());
    }

    public string DataName
    {
      get => this.dataName;
      set => this.NotifyPropertyChanged(nameof(this.DataName), ref this.dataName, value);
    }

    public ITypeParameter SelectedParameterType
    {
      get => this.selectedParameterType;
      set
      {
        this.NotifyPropertyChanged(nameof(this.SelectedParameterType), ref this.selectedParameterType, value);

        switch (this.selectedParameterType.Type)
        {
          case ParameterType.Integer:
            this.Parameter1Name = (this.selectedParameterType as IntegerTypeParameter).IntegerName;
            this.setParam1 = (typeParam, value) => (typeParam as IntegerTypeParameter).IntegerValue = int.Parse(value);
            break;
          case ParameterType.IntegerInteger:
            this.Parameter1Name = (this.selectedParameterType as IntegerIntegerTypeParameter).Integer1Name;
            this.Parameter2Name = (this.selectedParameterType as IntegerIntegerTypeParameter).Integer2Name;
            this.setParam1 = (typeParam, value) => (typeParam as IntegerIntegerTypeParameter).Integer1Value = int.Parse(value);
            this.setParam2 = (typeParam, value) => (typeParam as IntegerIntegerTypeParameter).Integer2Value = int.Parse(value);
            break;
          case ParameterType.IntegerBoolean:
            this.Parameter1Name = (this.selectedParameterType as IntegerBooleanTypeParameter).IntegerName;
            this.Parameter2Name = (this.selectedParameterType as IntegerBooleanTypeParameter).BooleanName;
            this.setParam1 = (typeParam, value) => (typeParam as IntegerBooleanTypeParameter).IntegerValue = int.Parse(value);
            this.setParam2 = (typeParam, value) => (typeParam as IntegerBooleanTypeParameter).BooleanValue = bool.Parse(value);
            break;
        }
      }
    }

    public string Parameter1Name
    {
      get => this.parameter1Name;
      set => this.NotifyPropertyChanged(nameof(this.Parameter1Name), ref this.parameter1Name, value);
    }

    public string Parameter2Name
    {
      get => this.parameter2Name;
      set => this.NotifyPropertyChanged(nameof(this.Parameter2Name), ref this.parameter2Name, value);
    }

    public string Parameter1Value
    {
      get => this.parameter1Value;
      set
      {
        this.NotifyPropertyChanged(nameof(this.Parameter1Value), ref this.parameter1Value, value);
        this.setParam1(this.SelectedParameterType, value);
      }
    }

    public string Parameter2Value
    {
      get => this.parameter2Value;
      set
      {
        this.NotifyPropertyChanged(nameof(this.Parameter2Value), ref this.parameter2Value, value);
        this.setParam2(this.SelectedParameterType, value);
      }
    }
  }
}
