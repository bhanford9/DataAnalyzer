using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
{
    internal interface IActionsSummaryViewModel : INotifyPropertyChanged
    {
        string ConfigName { get; set; }
        IExcelEntitySpecification ExcelEntityType { get; }
        ObservableCollection<IActionSummaryTreeViewItem> HierarchicalSummaries { get; }
        ICommand SaveConfiguration { get; }

        void LoadActionsFromModel(IDataConfiguration configuration);
    }
}