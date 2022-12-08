using DataAnalyzer.Services;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal interface IActionParameters : INotifyPropertyChanged
    {
        string Name { get; set; }

        ActionCategory ActionCategory { get; }

        string ToString();
    }
}