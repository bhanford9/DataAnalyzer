using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
{
    internal class ActionsSummaryViewModel : BasePropertyChanged, IActionsSummaryViewModel
    {
        // Stats model probably isn't the right way to do this. Instead...
        //   1. The Application side ViewModel should push down to its Model
        //   2. The Summary side Model should react to those changes and update itself
        //   3. The Summary side View Model should react to its Model's changes
        private readonly IStatsModel statsModel;
        private readonly IStructureExecutiveCommissioner executiveCommissioner;
        private readonly IActionsSummaryModel actionsSummaryModel;

        private string configName = string.Empty;

        private readonly BaseCommand saveConfiguration;

        public ActionsSummaryViewModel(
            IStatsModel statsModel,
            IStructureExecutiveCommissioner structureExecutiveCommissioner,
            IActionsSummaryModel actionsSummaryModel,
            IExcelEntitySpecification excelEntityType)
        {
            this.statsModel = statsModel;
            executiveCommissioner = structureExecutiveCommissioner;
            this.actionsSummaryModel = actionsSummaryModel;
            ExcelEntityType = excelEntityType;

            saveConfiguration = new BaseCommand(obj => DoSaveConfiguration());

            this.statsModel.PropertyChanged += StatsModelPropertyChanged;
            this.actionsSummaryModel.PropertyChanged += ActionsSummaryModelPropertyChanged;
        }

        public ObservableCollection<IActionSummaryTreeViewItem> HierarchicalSummaries { get; } = new();

        public ICommand SaveConfiguration => saveConfiguration;

        public IExcelEntitySpecification ExcelEntityType { get; }

        public string ConfigName
        {
            get => configName;
            set => NotifyPropertyChanged(ref configName, value);
        }

        public void LoadActionsFromModel(IDataConfiguration configuration)
        {
            if (HierarchicalSummaries.Count == 0)
            {
                statsModel.StructureStats(configuration);
                InitializeFromStats();
            }

            actionsSummaryModel.LoadHierarchicalSummariesFromModel(HierarchicalSummaries.First());
        }

        private void DoSaveConfiguration()
        {
            if (!string.IsNullOrEmpty(configName))
            {
                actionsSummaryModel.SaveConfiguration(configName);
                executiveCommissioner.SaveConfiguration();
            }
            else
            {
                // TODO
            }
        }

        private void InitializeFromStats()
        {
            HierarchicalSummaries.Clear();
            HierarchicalSummaries.Add(new ActionSummaryTreeViewItem { Name = "All Workbooks" });
            actionsSummaryModel.LoadHierarchicalSummariesFromStats(HierarchicalSummaries.First());
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(statsModel.HeirarchalStats):
                    InitializeFromStats();
                    break;
            }
        }

        private void ActionsSummaryModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case WorkbookActionApplicationModel.ACTION_APPLIED_KEY:
                    //this.actionsSummaryModel.LoadHierarchicalSummariesFromModel(this.HierarchicalSummaries.First());
                    break;
            }
        }
    }
}
