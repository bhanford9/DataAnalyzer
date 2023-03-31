using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface IColumnSpecificationViewModel : INotifyPropertyChanged
    {
        bool AllColumns { get; set; }
        string ColumnName { get; set; }
        bool ColumnNameEnabled { get; set; }
        string DataName { get; set; }
        bool DataNameEnabled { get; set; }
        int NthColumn { get; set; }
        bool NthColumnEnabled { get; set; }
        bool RadiosEnabled { get; set; }
        bool UseColumnName { get; set; }
        bool UseDataName { get; set; }
        bool UseNthColumn { get; set; }
    }
}