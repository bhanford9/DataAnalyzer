using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal abstract class DataTypeConfigViewModel : BasePropertyChanged, IDataTypeConfigViewModel
    {
        private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;
        protected readonly ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;

        private string dataName = string.Empty;
        private string dataTypeName = string.Empty;
        private string example = string.Empty;
        private int startingSelectedIndex = 0;

        public DataTypeConfigViewModel(ITypeParameter typeParameter)
        {
            this.TypeParameter = typeParameter;
            this.DataName = typeParameter?.DataName ?? string.Empty;
            this.dataTypeName = typeParameter?.ExcelTypeName ?? "Invalid Data";
            this.ParameterTypes = this.excelDataTypeLibrary.GetParameterTypes().Select(x => x.ExcelTypeName).ToList();

            // TODO --> setup selected item based on configuration
        }

        public List<string> ParameterTypes { get; init; } = new List<string>();

        public ITypeParameter TypeParameter { get; private set; }

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

        public string DataTypeName
        {
            get => this.dataTypeName;
            set
            {
                this.NotifyPropertyChanged(ref this.dataTypeName, value);
                if (excelDataTypeLibrary.NamedTypeParameters.TryGetValue(value, out ITypeParameter val))
                {
                    this.TypeParameter = Activator.CreateInstance(val.GetType(), val) as ITypeParameter;
                    this.TypeParameter.UpdateValues(this.GetNamedValues());
                    this.TypeParameter.DataName = this.DataName;

                    // Need to send data to model so model can change me into a new type of DataTypeConfig
                    this.UpdateTypeParam(this.TypeParameter);
                    this.Example = this.TypeParameter.Example;

                    for (int i = 0; i < this.excelSetupModel.WorkingParameterTypes.Count; i++)
                    {
                        if (this.excelSetupModel.WorkingParameterTypes[i].DataName.Equals(this.TypeParameter.DataName))
                        {
                            this.excelSetupModel.WorkingParameterTypes[i] = this.TypeParameter;
                            this.excelSetupModel.UpdateDataTypeForMember(this.DataName, this.TypeParameter);
                            this.excelSetupModel.BroadcastExcelDataTypeUpdated(this.DataName);
                            break;
                        }
                    }

                    //for (int i = 0; i < this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes.Count; i++)
                    //{
                    //    if (this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes[i].DataName.Equals(this.TypeParameter.DataName))
                    //    {
                    //        this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes[i] = this.TypeParameter;
                    //        this.excelSetupModel.UpdateDataTypeForMember(this.DataName, this.TypeParameter);
                    //        this.excelSetupModel.BroadcastExcelDataTypeUpdated(this.DataName);
                    //        break;
                    //    }
                    //}
                }
            }
        }

        public string Example
        {
            get => this.example;
            set => this.NotifyPropertyChanged(ref this.example, value);
        }

        public abstract void UpdateTypeParam(ITypeParameter param);

        protected abstract IReadOnlyDictionary<string, object> GetNamedValues();

        public override bool Equals(object obj)
        {
            return 
                obj != null && 
                obj.GetType() == this.GetType() &&
                obj is IDataTypeConfigViewModel o &&
                this.DataTypeName.Equals(o.DataTypeName) &&
                this.DataName.Equals(o.DataName) &&
                this.TypeParameter.Equals(o.TypeParameter);
        }

        // Should not be using a model as a view model
        //public ITypeParameter SelectedParameterType
        //{
        //    get => this.selectedParameterType;
        //    set
        //    {
        //        if (this.selectedParameterType == null ||
        //            string.IsNullOrEmpty(this.selectedParameterType.DataName) ||
        //            !string.IsNullOrEmpty(value.DataName))
        //        {
        //            this.selectedParameterType = value;// (ITypeParameter)Activator.CreateInstance(value.GetType(), value);
        //            this.selectedParameterType.DataName = this.DataName;
        //        }

        //        this.NotifyPropertyChanged(nameof(this.SelectedParameterType));
        //        //this.excelSetupModel.UpdateDataTypeForMember(this.DataName, this.selectedParameterType);
        //    }
        //}
    }
}
