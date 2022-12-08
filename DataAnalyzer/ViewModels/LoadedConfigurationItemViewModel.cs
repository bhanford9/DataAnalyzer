using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels
{
    internal class LoadedConfigurationItemViewModel : BasePropertyChanged
    {
        private string title = string.Empty;

        public LoadedConfigurationItemViewModel()
        {
        }

        public ObservableCollection<string> ConfigData { get; }
          = new ObservableCollection<string>();

        public string Title
        {
            get => this.title;
            set => this.NotifyPropertyChanged(ref this.title, value);
        }
    }
}
