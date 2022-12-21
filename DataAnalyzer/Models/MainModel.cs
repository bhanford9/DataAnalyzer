using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;

namespace DataAnalyzer.Models
{
    internal class MainModel : BasePropertyChanged
    {
        private LoadedDataContent loadedDataContent = new();
        private LoadedDataStructure loadedDataStructure = new();
        private LoadedInputFiles loadedInputFiles = new();

        public MainModel()
        {
        }

        public LoadedDataContent LoadedDataContent
        {
            get => this.loadedDataContent;
            set => this.NotifyPropertyChanged(ref this.loadedDataContent, value);
        }

        public LoadedDataStructure LoadedDataStructure
        {
            get => this.loadedDataStructure;
            set => this.NotifyPropertyChanged(ref this.loadedDataStructure, value);
        }

        public LoadedInputFiles LoadedInputFiles
        {
            get => this.loadedInputFiles;
            set => this.NotifyPropertyChanged(ref this.loadedInputFiles, value);
        }
    }
}
