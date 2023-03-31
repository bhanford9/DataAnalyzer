using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
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
            ExcelEntityType excelEntityType)
        {
            this.statsModel = statsModel;
            this.executiveCommissioner = structureExecutiveCommissioner;
            this.actionsSummaryModel = actionsSummaryModel;
            this.ExcelEntityType = excelEntityType;

            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());

            this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
            this.actionsSummaryModel.PropertyChanged += this.ActionsSummaryModelPropertyChanged;
        }

        public ObservableCollection<IActionSummaryTreeViewItem> HierarchicalSummaries { get; } = new();

        public ICommand SaveConfiguration => this.saveConfiguration;

        public ExcelEntityType ExcelEntityType { get; }

        public string ConfigName
        {
            get => this.configName;
            set => this.NotifyPropertyChanged(ref this.configName, value);
        }

        public void LoadActionsFromModel(IDataConfiguration configuration)
        {
            if (this.HierarchicalSummaries.Count == 0)
            {
                this.statsModel.StructureStats(configuration);
                this.InitializeFromStats();
            }

            this.actionsSummaryModel.LoadHierarchicalSummariesFromModel(this.HierarchicalSummaries.First());
        }

        private void DoSaveConfiguration()
        {
            if (!string.IsNullOrEmpty(this.configName))
            {
                this.actionsSummaryModel.SaveConfiguration(this.configName);
                this.executiveCommissioner.SaveConfiguration();
            }
            else
            {
                // TODO
            }
        }

        private void InitializeFromStats()
        {
            this.HierarchicalSummaries.Clear();
            this.HierarchicalSummaries.Add(new ActionSummaryTreeViewItem { Name = "All Workbooks" });
            this.actionsSummaryModel.LoadHierarchicalSummariesFromStats(this.HierarchicalSummaries.First());
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.statsModel.HeirarchalStats):
                    this.InitializeFromStats();
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
