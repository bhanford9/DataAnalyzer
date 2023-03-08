using DataAnalyzer.Common.Mvvm;
using System.ComponentModel;

namespace DataAnalyzer.Models.ImportModels
{
    internal class ImportModel : BasePropertyChanged, IImportModel
    {
        private string selectedScraperCategory = string.Empty;

        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        public ImportModel()
        {
            this.SelectedScraperCategory = Properties.Settings.Default.LastSelectedScraperType;

            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
        }

        public string SelectedScraperCategory
        {
            get => this.selectedScraperCategory;
            set
            {
                this.mainModel.LoadedInputFiles.DataType = value;
                this.NotifyPropertyChanged(ref this.selectedScraperCategory, value);

                Properties.Settings.Default.LastSelectedScraperType = value;
                Properties.Settings.Default.Save();
            }
        }

        private void MainModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ScraperCategory):
                    this.SelectedScraperCategory = this.mainModel.ScraperCategory.ToString();
                    break;
            }
        }
    }
}
