using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExecutionViewModels
{
    internal class ClassCreationSetupViewModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly StructureExecutiveCommissioner executiveCommissioner = BaseSingleton<StructureExecutiveCommissioner>.Instance;
        private readonly ClassCreationSetupModel setupModel = BaseSingleton<ClassCreationSetupModel>.Instance;

        private string className = string.Empty;
        private string selectedConfigDirectory = string.Empty;
        private string configName = string.Empty;
        private string classPreviewText = string.Empty;
        private bool isPreviewing = false;

        private readonly BaseCommand loadInData;
        private readonly BaseCommand selectConfigDirectory;
        private readonly BaseCommand setAllPropertiesToStrings;
        private readonly BaseCommand autoDetectAllProperties;
        private readonly BaseCommand previewClass;
        private readonly BaseCommand exportClass;
        private readonly BaseCommand saveConfiguration;
        private readonly BaseCommand closePreview;
        private readonly BaseCommand copyAllText;

        public ClassCreationSetupViewModel()
        {
            this.loadInData = new BaseCommand(obj => this.DoLoadInData());
            this.selectConfigDirectory = new BaseCommand(obj => this.DoSelectConfigDirectory());
            this.setAllPropertiesToStrings = new BaseCommand(obj => this.DoSetAllPropertiesToStrings());
            this.autoDetectAllProperties = new BaseCommand(obj => this.DoAutoDetectAllProperties());
            this.previewClass = new BaseCommand(obj => this.DoPreviewClass());
            this.exportClass = new BaseCommand(obj => this.DoExportClass());
            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());
            this.closePreview = new BaseCommand(obj => this.DoClosePreview());
            this.copyAllText = new BaseCommand(obj => this.DoCopyAllText());

            this.SelectedConfigDirectory = this.setupModel.ClassCreationConfigModel.ConfigurationDirectory;

            this.setupModel.PropertyChanged += SetupModelPropertyChanged;
        }

        public ICommand LoadInData => this.loadInData;
        public ICommand SelectConfigDirectory => this.selectConfigDirectory;
        public ICommand SetAllPropertiesToStrings => this.setAllPropertiesToStrings;
        public ICommand AutoDetectAllProperties => this.autoDetectAllProperties;
        public ICommand PreviewClass => this.previewClass;
        public ICommand ExportClass => this.exportClass;
        public ICommand SaveConfiguration => this.saveConfiguration;
        public ICommand ClosePreview => this.closePreview;
        public ICommand CopyAllText => this.copyAllText;

        public ObservableCollection<PropertyData> PropertyItems { get; } = new();
        public ObservableCollection<ClassCreationConfigListItemViewModel> SavedConfigs { get; } = new();

        public string ClassName
        {
            get => this.className;
            set => this.NotifyPropertyChanged(ref this.className, value);
        }

        public string SelectedConfigDirectory
        {
            get => this.selectedConfigDirectory;
            set
            {
                // TODO --> The display of where the configurations are located is not good enough because
                // the code uses some keywords as sub directories of what is actually displayed

                this.NotifyPropertyChanged(ref this.selectedConfigDirectory, value);
                this.setupModel.ClassCreationConfigModel.ConfigurationDirectory = value;

                this.setupModel.ClassCreationConfigModel.AcquireConfigurations();
                this.UpdateConfigurations();
            }
        }

        public string ConfigName
        {
            get => this.configName;
            set => this.NotifyPropertyChanged(ref this.configName, value);
        }

        public string ClassPreviewText
        {
            get => this.classPreviewText;
            set => this.NotifyPropertyChanged(ref this.classPreviewText, value);
        }

        public bool IsPreviewing
        {
            get => this.isPreviewing;
            set => this.NotifyPropertyChanged(ref this.isPreviewing, value);
        }

        private void DoLoadInData()
        {
            CsvNamesDataConfiguration dataConfig = this.executiveCommissioner.GetDataConfiguration<CsvNamesDataConfiguration>();
            this.statsModel.StructureStats(dataConfig);

            this.PropertyItems.Clear();

            this.ClassName = dataConfig.ClassName;

            foreach (var property in dataConfig.CsvNameAndProperties)
            {
                this.PropertyItems.Add(new PropertyData() { Name = property.PropertyName });
            }
        }

        private void DoSelectConfigDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectedConfigDirectory = folderBrowserDialog.SelectedPath;
            }
        }

        private void DoSetAllPropertiesToStrings()
        {
            foreach (var prop in this.PropertyItems)
            {
                prop.SelectedType = ClassCreationConstants.STRING_TYPE;
            }
        }

        private void DoAutoDetectAllProperties()
        {
        }

        private void DoPreviewClass()
        {
            string classString = this.setupModel.GetClassString(this.className, this.PropertyItems.ToList());
            this.ClassPreviewText = classString;
            this.IsPreviewing= true;
        }

        private void DoExportClass()
        {
            string classString = this.setupModel.GetClassString(this.className, this.PropertyItems.ToList());
        }

        private void DoSaveConfiguration()
        {
            this.setupModel.ClassCreationConfigModel.ClassProperties.Properties.Clear();

            foreach (var prop in this.PropertyItems)
            {
                // TODO this should maybe go through the setup layer instead
                this.setupModel.ClassCreationConfigModel.ClassProperties.Properties.Add(new ClassPropertyData()
                {
                    Name = prop.Name,
                    Accessibility = prop.SelectedAccessibility,
                    DataType = prop.SelectedType
                });
            }

            this.setupModel.ClassCreationConfigModel.SaveWorkingConfiguration(this.configName);
            this.executiveCommissioner.SaveConfiguration();

            this.UpdateConfigurations();
        }

        private void DoClosePreview() => this.IsPreviewing = false;

        private void DoCopyAllText() => Clipboard.SetText(this.classPreviewText);

        private void UpdateConfigurations()
        {
            this.SavedConfigs.Clear();
            foreach (var config in this.setupModel.ClassCreationConfigModel.Configurations)
            {
                this.SavedConfigs.Add(new ClassCreationConfigListItemViewModel()
                {
                    IsRemovable = true,
                    Value = config
                });
            }
        }

        private void SetupModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.setupModel.DataItems):
                    this.PropertyItems.Clear();
                    foreach (var dataItem in this.setupModel.DataItems)
                    {
                        this.PropertyItems.Add(new PropertyData()
                        {
                            SelectedAccessibility = dataItem.SelectedAccessibility,
                            SelectedType = dataItem.SelectedType,
                            Name = dataItem.Name
                        });
                    }
                    break;
                case nameof(this.setupModel.ConfigurationName):
                    this.ConfigName = this.setupModel.ConfigurationName;
                    break;
            }
        }
    }
}
