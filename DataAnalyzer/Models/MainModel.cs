using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;

namespace DataAnalyzer.Models
{
    internal class MainModel : BasePropertyChanged
    {
        private LoadedDataContent loadedDataContent = new LoadedDataContent();
        private LoadedDataStructure loadedDataStructure = new LoadedDataStructure();
        private LoadedInputFiles loadedInputFiles = new LoadedInputFiles();

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
