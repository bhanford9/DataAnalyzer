using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal interface IExcelAction : INotifyPropertyChanged
    {
        IActionParameters ActionParameters { get; set; }
        string ActionParameterType { get; set; }
        string Description { get; set; }
        bool IsBuiltIn { get; set; }
        string Name { get; set; }

        IExcelAction Clone();
    }
}