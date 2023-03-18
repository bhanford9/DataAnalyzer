using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.ImportViewModels;
using DataScraper.DataScrapers.ImportTypes;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ImportExecutiveCommissioner : BasePropertyChanged
    {
        private bool displayFileImport = false;

        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        // this may need to be dependent on more than just the import type
        private readonly IReadOnlyDictionary<IImportType, IImportViewModel> viewModelMap;

        public ImportExecutiveCommissioner()
        {
            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
            //this.SetDisplay();

            viewModelMap = new Dictionary<IImportType, IImportViewModel>()
            {
                { new FileImportType(), new ImportFromFileViewModel() },
            };
        }

        public bool DisplayFileImport
        {
            get => this.displayFileImport;
            set => this.NotifyPropertyChanged(ref this.displayFileImport, value);
        }

        public void SetDisplay()
        {
            this.DisplayFileImport = false;

            if (this.mainModel.ImportType.Name.Equals(new FileImportType().Name))
            {
                this.DisplayFileImport = true;
            }
        }

        private void MainModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ImportType):
                case nameof(this.mainModel.ScraperCategory):
                case nameof(this.mainModel.ScraperFlavor):
                    this.SetDisplay();
                    break;
            }
        }

    }
}
