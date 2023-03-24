﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.ImportViewModels;
using DataScraper.DataScrapers.ImportTypes;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ImportExecutiveCommissioner : BasePropertyChanged
    {
        private bool displayFileImport = false;

        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        // this may need to be dependent on more than just the import type
        private readonly IReadOnlyDictionary<IImportType, IImportViewModel> viewModelMap;

        public ImportExecutiveCommissioner()
        {
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
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

            if (this.configurationModel.ImportType.Name.Equals(new FileImportType().Name))
            {
                this.DisplayFileImport = true;
            }
        }

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportType):
                case nameof(this.configurationModel.Category):
                case nameof(this.configurationModel.Flavor):
                    this.SetDisplay();
                    break;
            }
        }

    }
}
