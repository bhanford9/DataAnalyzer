using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class CsvCSharpStringClassSetupViewModel : DataStructureSetupViewModel<CsvNamesDataConfiguration>, ICsvCSharpStringClassSetupViewModel
    {
        private string className = string.Empty;

        // optionally may want to move this into the parentViewModel as the interface
        private readonly ICsvCSharpStringClassSetupModel model;

        public CsvCSharpStringClassSetupViewModel(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            IStatsModel statsModel,
            INotSupportedSetupViewModel defaultViewModel,
            ICsvCSharpStringClassSetupModel model)
            : base(configurationModel, statsModel, mainModel, model)
        {
            this.model = model;
            this.Default = defaultViewModel;
            this.model.PropertyChanged += this.ModelPropertyChanged;
        }

        public ObservableCollection<IStringPropertyRowViewModel> CsvPropertyRows { get; set; } = new();

        public string ClassName
        {
            get => this.className;
            set => this.NotifyPropertyChanged(ref this.className, value);
        }

        public override IDataStructureSetupViewModel Default { get; }

        public override bool IsValidSetup(out string reason)
        {
            reason = string.Empty;

            if (string.IsNullOrEmpty(this.ClassName))
            {
                reason = "Class Name cannot be left empty";
                return false;
            }

            return true;
        }

        public override void ClearConfiguration()
        {
            //this.SelectedDataType = ImportExportKey.NotApplicable.ToString();
        }

        public override void LoadViewModelFromConfiguration()
        {
            this.ConfigurationName = this.model.DataConfiguration.Name;
            this.ClassName = this.model.DataConfiguration.ClassName;
            this.CsvPropertyRows.Clear();

            this.model.DataConfiguration.CsvNameAndProperties.ToList().ForEach(x =>
            {
                this.CsvPropertyRows.Add(new StringPropertyRowViewModel()
                {
                    SerializedName = x.CsvName,
                    PropertyName = x.PropertyName,
                    Include = x.Include,
                });
            });
        }

        public override void ApplyConfiguration()
        {
            this.model.CreateNewDataConfiguration();

            this.model.DataConfiguration.Name = this.ConfigurationName;
            this.model.DataConfiguration.ClassName = this.ClassName;
            this.CsvPropertyRows
                .Where(row => row.Include)
                .ToList()
                .ForEach(row => this.model.DataConfiguration.CsvNameAndProperties.Add((row.SerializedName, row.PropertyName, row.Include)));
        }

        public override void SaveConfiguration() => this.model.SaveConfiguration();

        public override void Initialize()
        {
            List<CsvNamesStats> stats = this.statsModel.Stats.OfType<CsvNamesStats>().ToList();
            this.CsvPropertyRows.Clear();

            if (stats.Any())
            {
                stats[0].CsvNames
                    .ToList()
                    .ForEach(name => this.CsvPropertyRows.Add(new StringPropertyRowViewModel()
                    {
                        SerializedName = name,
                        PropertyName = name,
                        Include = true
                    }));
            }
        }

        public override string GetDisplayStringName() => nameof(StructureExecutiveCommissioner.DisplayCsvToClassSetup);

        private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // may not be necessary for this class
        }
    }
}
