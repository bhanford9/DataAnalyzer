using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
    internal class DataTypeSelectionViewModel : BasePropertyChanged
    {
        private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;

        private string dataName = string.Empty;
        private ITypeParameter selectedParameterType;
        private int startingSelectedIndex = 0;

        private string parameter1Name = string.Empty;
        private string parameter2Name = string.Empty;

        private string parameter1Value = string.Empty;
        private string parameter2Value = string.Empty;

        private Action<ITypeParameter, string> setParam1;
        private Action<ITypeParameter, string> setParam2;

        public DataTypeSelectionViewModel()
        {
        }

        // This is getting ugly.
        // Might want to look into handling through inheritance instead
        public DataTypeSelectionViewModel(
          string name,
          ITypeParameter typeParameter,
          params object[] nameValuePairs)
        {
            this.DataName = name;
            this.SelectedParameterType = typeParameter;

            if (nameValuePairs.Length > 1)
            {
                this.Parameter1Name = nameValuePairs[0].ToString();
                this.Parameter1Value = nameValuePairs[1].ToString();

                if (nameValuePairs.Length > 3)
                {
                    this.Parameter2Name = nameValuePairs[2].ToString();
                    this.Parameter2Value = nameValuePairs[3].ToString();
                }
            }

            switch (typeParameter.Type)
            {
                case ParameterType.Integer:
                    (typeParameter as IntegerTypeParameter).IntegerName = this.Parameter1Name;
                    (typeParameter as IntegerTypeParameter).IntegerValue = int.Parse(this.Parameter1Value);
                    break;
                case ParameterType.IntegerInteger:
                    (typeParameter as IntegerIntegerTypeParameter).Integer1Name = this.Parameter1Name;
                    (typeParameter as IntegerIntegerTypeParameter).Integer1Value = int.Parse(this.Parameter1Value);
                    (typeParameter as IntegerIntegerTypeParameter).Integer2Name = this.Parameter2Name;
                    (typeParameter as IntegerIntegerTypeParameter).Integer2Value = int.Parse(this.Parameter2Value);
                    break;
                case ParameterType.IntegerBoolean:
                    (typeParameter as IntegerBooleanTypeParameter).IntegerName = this.Parameter1Name;
                    (typeParameter as IntegerBooleanTypeParameter).IntegerValue = int.Parse(this.Parameter1Value);
                    (typeParameter as IntegerBooleanTypeParameter).BooleanName = this.Parameter2Name;
                    (typeParameter as IntegerBooleanTypeParameter).BooleanValue = bool.Parse(this.Parameter2Value);
                    break;
            }

            this.SelectedParameterType = typeParameter;
        }

        public string DataName
        {
            get => this.dataName;
            set => this.NotifyPropertyChanged(ref this.dataName, value);
        }

        public int StartingSelectedIndex
        {
            get => this.startingSelectedIndex;
            set => this.NotifyPropertyChanged(ref this.startingSelectedIndex, value);
        }

        public ITypeParameter SelectedParameterType
        {
            get => this.selectedParameterType;
            set
            {
                if (this.selectedParameterType == null || string.IsNullOrEmpty(this.selectedParameterType.DataName) || !string.IsNullOrEmpty(value.DataName))
                {
                    this.selectedParameterType = (ITypeParameter)Activator.CreateInstance(value.GetType(), value);
                    this.selectedParameterType.DataName = this.DataName;
                }

                switch (this.selectedParameterType.Type)
                {
                    case ParameterType.Integer:
                        this.Parameter1Name = (this.selectedParameterType as IntegerTypeParameter).IntegerName;
                        this.setParam1 = (typeParam, value) => (typeParam as IntegerTypeParameter).IntegerValue = int.Parse(value);
                        this.parameter1Value = this.Parameter1Value;
                        break;
                    case ParameterType.IntegerInteger:
                        this.Parameter1Name = (this.selectedParameterType as IntegerIntegerTypeParameter).Integer1Name;
                        this.Parameter2Name = (this.selectedParameterType as IntegerIntegerTypeParameter).Integer2Name;
                        this.setParam1 = (typeParam, value) => (typeParam as IntegerIntegerTypeParameter).Integer1Value = int.Parse(value);
                        this.setParam2 = (typeParam, value) => (typeParam as IntegerIntegerTypeParameter).Integer2Value = int.Parse(value);
                        this.parameter1Value = this.Parameter1Value;
                        this.parameter2Value = this.Parameter2Value;
                        break;
                    case ParameterType.IntegerBoolean:
                        this.Parameter1Name = (this.selectedParameterType as IntegerBooleanTypeParameter).IntegerName;
                        this.Parameter2Name = (this.selectedParameterType as IntegerBooleanTypeParameter).BooleanName;
                        this.setParam1 = (typeParam, value) => (typeParam as IntegerBooleanTypeParameter).IntegerValue = int.Parse(value);
                        this.setParam2 = (typeParam, value) => (typeParam as IntegerBooleanTypeParameter).BooleanValue = bool.Parse(value);
                        this.parameter1Value = this.Parameter1Value;
                        this.parameter2Value = this.Parameter2Value;
                        break;
                }

                this.NotifyPropertyChanged(nameof(this.SelectedParameterType));
                this.excelSetupModel.UpdateDataTypeForMember(this.DataName, this.selectedParameterType);
                //}
            }
        }

        public string Parameter1Name
        {
            get => this.parameter1Name;
            set => this.NotifyPropertyChanged(ref this.parameter1Name, value);
        }

        public string Parameter2Name
        {
            get => this.parameter2Name;
            set => this.NotifyPropertyChanged(ref this.parameter2Name, value);
        }

        public string Parameter1Value
        {
            get => this.parameter1Value;
            set
            {
                this.NotifyPropertyChanged(ref this.parameter1Value, value);
                this.setParam1?.Invoke(this.SelectedParameterType, value);
            }
        }

        public string Parameter2Value
        {
            get => this.parameter2Value;
            set
            {
                this.NotifyPropertyChanged(ref this.parameter2Value, value);
                this.setParam2?.Invoke(this.SelectedParameterType, value);
            }
        }
    }
}
