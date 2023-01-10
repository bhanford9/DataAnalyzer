using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
    internal class ConfigurationModel : BasePropertyChanged
    {
        private readonly DataParameterLibrary dataParameterLibrary = new();
        private IDataParameterCollection dataParameterCollection = null;
        private string configurationDirectory = string.Empty;
        private string configurationName = string.Empty;
        private string savedDataFilePath = string.Empty;

        private StatType selectedStatType = StatType.NotApplicable;
        private ExportType selectedExportType = ExportType.NotApplicable;

        public StatType SelectedDataType
        {
            get => this.selectedStatType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedStatType, value);
                this.DataParameterCollection = this.dataParameterLibrary.GetParameters(value);
            }
        }

        public ExportType SelectedExportType
        {
            get => this.selectedExportType;
            set => this.NotifyPropertyChanged(ref this.selectedExportType, value);
        }

        public IDataParameterCollection DataParameterCollection
        {
            get => this.dataParameterCollection;
            set => this.NotifyPropertyChanged(ref this.dataParameterCollection, value);
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                Properties.Settings.Default.LastUsedConfigurationDirectory = value;
                Properties.Settings.Default.Save();
            }
        }

        public string ConfigurationName
        {
            get => this.configurationName;
            set => this.NotifyPropertyChanged(ref this.configurationName, value);
        }

        public string SavedDataFilePath
        {
            get => this.savedDataFilePath;
            set => this.NotifyPropertyChanged(ref this.savedDataFilePath, value);
        }
    }
}
