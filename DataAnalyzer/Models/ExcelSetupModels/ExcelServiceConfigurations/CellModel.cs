using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
    internal class CellModel : BasePropertyChanged
    {
        public ICollection<ExcelAction> CellActions { get; set; } = new List<ExcelAction>();

        public object Value { get; set; } = new object();

        public ITypeParameter DataType { get; set; }

        public int ColumnIndex { get; set; }

        public string DataMemberName { get; set; } = string.Empty;
    }
}
