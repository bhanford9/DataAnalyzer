using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.Utilities;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
    internal class ImportConfigurationViewModel : BasePropertyChanged
    {
        private bool categoryIsSelectable = false;
        private bool flavorIsSelectable = false;

        private IImportType selectedImportType;
        private IScraperCategory selectedScraperCategory;
        private IScraperFlavor selectedScraperFlavor;
        private IReadOnlyCollection<IScraperCategory> scraperCategories = new List<IScraperCategory>();
        private IReadOnlyCollection<IScraperFlavor> scrpaerFlavors = new List<IScraperFlavor>();

        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly DataConverterLibrary dataConverters = BaseSingleton<DataConverterLibrary>.Instance;
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        public ImportConfigurationViewModel()
        {
            this.ImportTypes = this.dataConverters.GetImportTypes();

            if (!this.configurationModel.HasLoaded)
            {
                this.configurationModel.LoadConfiguration();
            }

            if (this.configurationModel.HasLoaded)
            {
                this.ApplyConfiguration();
            }

            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public ImportExecutiveCommissioner ExecutiveCommissioner { get; }
            = BaseSingleton<ImportExecutiveCommissioner>.Instance;

        public bool CategoryIsSelectable
        {
            get => this.categoryIsSelectable;
            set => this.NotifyPropertyChanged(ref this.categoryIsSelectable, value);
        }

        public bool FlavorIsSelectable
        {
            get => this.flavorIsSelectable;
            set => this.NotifyPropertyChanged(ref this.flavorIsSelectable, value);
        }

        public IImportType SelectedImportType
        {
            get => this.selectedImportType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedImportType, value);
                this.ScraperCategories = this.dataConverters.GetCategories(value);
                this.CategoryIsSelectable = true;
                this.mainModel.ImportType = value;
            }
        }

        public IScraperCategory SelectedScraperCategory
        {
            get => this.selectedScraperCategory;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperCategory, value);
                this.ScraperFlavors = this.dataConverters.GetFlavors(this.SelectedImportType, value);
                this.FlavorIsSelectable = true;
                this.mainModel.ScraperCategory = value;
            }
        }

        public IScraperFlavor SelectedScraperFlavor
        {
            get => this.selectedScraperFlavor;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperFlavor, value);
                this.mainModel.ScraperFlavor = value;
            }
        }

        public IReadOnlyCollection<IImportType> ImportTypes { get; private set; }

        public IReadOnlyCollection<IScraperCategory> ScraperCategories
        {
            get => this.scraperCategories;
            private set => this.NotifyPropertyChanged(ref this.scraperCategories, value);
        }

        public IReadOnlyCollection<IScraperFlavor> ScraperFlavors
        {
            get => this.scrpaerFlavors;
            private set => this.NotifyPropertyChanged(ref this.scrpaerFlavors, value);
        }

        private void ApplyConfiguration()
        {
            this.SelectedImportType = this.configurationModel.ImportType;
            this.SelectedScraperCategory = this.configurationModel.Category;
            this.SelectedScraperFlavor = this.configurationModel.Flavor;
            this.ExecutiveCommissioner.SetDisplay();
        }

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportType):
                    this.SelectedImportType = this.configurationModel.ImportType;
                    break;
                case nameof(this.configurationModel.Category):
                    this.SelectedScraperCategory = this.configurationModel.Category;
                    break;
                case nameof(this.configurationModel.Flavor):
                    this.SelectedScraperFlavor = this.configurationModel.Flavor;
                    break;
            }
        }
    }
}
