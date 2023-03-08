using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ImportModels;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ImportViewModels
{
    internal abstract class ImportViewModel : BasePropertyChanged, IImportViewModel
    {
        protected abstract IImportModel ImportModel { get; }

        public ImportViewModel()
        {
            this.ImportModel.PropertyChanged += this.ImportModelPropertyChanged;
        }

        public string SelectedScraperCategory => this.ImportModel.SelectedScraperCategory;

        private void ImportModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.ImportModel.SelectedScraperCategory):
                    this.NotifyPropertyChanged(nameof(this.SelectedScraperCategory));
                    break;
            }
        }
    }
}
