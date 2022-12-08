using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal interface IDataTypeConfigViewModel : INotifyPropertyChanged
    {
        string DataTypeName { get; set; }
        int StartingSelectedIndex { get; set; }
        string DataName { get; set; }
        string Example { get; set; }
        ITypeParameter TypeParameter { get; }
    }
}
