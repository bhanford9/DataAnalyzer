using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal interface IColumnSpecificationParameters : INotifyPropertyChanged
    {
        bool AllColumns { get; set; }
        string ColumnName { get; set; }
        string DataName { get; set; }
        int NthColumn { get; set; }
        bool UseColumnName { get; set; }
        bool UseDataName { get; set; }
        bool UseNthColumn { get; set; }

        IColumnSpecificationParameters Clone();
        string ToString();
    }
}