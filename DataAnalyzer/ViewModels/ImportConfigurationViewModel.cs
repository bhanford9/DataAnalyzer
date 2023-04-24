using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
    internal class ImportConfigurationViewModel : BasePropertyChanged, IImportConfigurationViewModel
    {
        private bool categoryIsSelectable = false;
        private bool flavorIsSelectable = false;

        private IImportType selectedImportType = new NotApplicableImportType();
        private IScraperCategory selectedScraperCategory = new NotApplicableScraperCategory();
        private IScraperFlavor selectedScraperFlavor = new NotApplicableScraperFlavor();
        private IReadOnlyCollection<IScraperCategory> scraperCategories = new List<IScraperCategory>();
        private IReadOnlyCollection<IScraperFlavor> scrpaerFlavors = new List<IScraperFlavor>();

        private readonly IDataConverterLibrary dataConverters;
        private readonly IConfigurationModel configurationModel;

        public ImportConfigurationViewModel(
            IConfigurationModel configModel,
            IImportExecutiveCommissioner executiveCommissioner,
            IDataConverterLibrary dataConverters)
        {
            this.configurationModel = configModel;
            this.ExecutiveCommissioner = executiveCommissioner;
            this.dataConverters = dataConverters;
            this.ImportTypes = this.dataConverters.GetImportTypes();

            this.ApplyConfiguration();

            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public IImportExecutiveCommissioner ExecutiveCommissioner { get; }

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
                this.ScraperCategories = this.dataConverters.GetCategories(value, true);
                this.CategoryIsSelectable = true;
                this.configurationModel.ImportType = value;
            }
        }

        public IScraperCategory SelectedScraperCategory
        {
            get => this.selectedScraperCategory;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperCategory, value);
                this.ScraperFlavors = this.dataConverters.GetFlavors(this.SelectedImportType, value, true);
                this.FlavorIsSelectable = true;
                this.configurationModel.Category = value;
            }
        }

        public IScraperFlavor SelectedScraperFlavor
        {
            get => this.selectedScraperFlavor;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperFlavor, value);
                this.configurationModel.Flavor = value;
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
