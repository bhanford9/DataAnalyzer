using DataAnalyzer.Common.Mvvm;
using System.ComponentModel;

namespace DataAnalyzer.Models.ImportModels
{
    internal class ImportModel : BasePropertyChanged, IImportModel
    {
        private string selectedScraperCategory = string.Empty;

        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        public ImportModel()
        {
            this.SelectedScraperCategory = Properties.Settings.Default.LastSelectedScraperType;

            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
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

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.Category):
                    this.SelectedScraperCategory = this.configurationModel.Category.ToString();
                    break;
            }
        }
    }
}
