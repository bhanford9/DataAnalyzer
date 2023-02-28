using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

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

        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly DataConverterLibrary dataConverterLibrary = new();
        private readonly EnumUtilities enumUtils = new();

        public ImportConfigurationViewModel()
        {
            this.ImportTypes = this.dataConverterLibrary.GetImportTypes();
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
                this.ScraperCategories = this.dataConverterLibrary.GetCategories(value);
                this.CategoryIsSelectable = true;
                this.mainModel.ImportType = value;
                // TODO (future) --> save last selected import type
                // TODO (future) --> load last used category for selected import type
            }
        }

        public IScraperCategory SelectedScraperCategory
        {
            get => this.selectedScraperCategory;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperCategory, value);
                this.ScraperFlavors = this.dataConverterLibrary.GetFlavors(this.SelectedImportType, value);
                this.FlavorIsSelectable = true;
                this.mainModel.ScraperCategory = value;
                // TODO (future) --> save last selected category for import type
                // TODO (future) --> load last used flavor for selected import-category combo type
            }
        }

        public IScraperFlavor SelectedScraperFlavor
        {
            get => this.selectedScraperFlavor;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedScraperFlavor, value);
                this.mainModel.ScraperFlavor = value;
                // TODO (future) --> save last selected flavor for import-category combo type
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
    }
}
