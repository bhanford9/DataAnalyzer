using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal interface IActionsSummaryViewModel : INotifyPropertyChanged
    {
        string ConfigName { get; set; }
        ExcelEntityType ExcelEntityType { get; }
        ObservableCollection<IActionSummaryTreeViewItem> HierarchicalSummaries { get; }
        ICommand SaveConfiguration { get; }

        void LoadActionsFromModel(IDataConfiguration configuration);
    }
}