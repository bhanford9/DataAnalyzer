using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.ImportViewModels;
using DataScraper.DataScrapers.ImportTypes;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

internal class ImportExecutiveCommissioner : BasePropertyChanged, IImportExecutiveCommissioner
{
    private bool displayFileImport = false;

    private readonly IConfigurationModel configurationModel;

    // this may need to be dependent on more than just the import type
    private readonly IReadOnlyDictionary<IImportType, IImportViewModel> viewModelMap;

    public ImportExecutiveCommissioner(
        IConfigurationModel configurationModel,
        IImportFromFileViewModel importFromFileViewModel)
    {
        this.configurationModel = configurationModel;
        configurationModel.PropertyChanged += ConfigurationModelPropertyChanged;

        viewModelMap = new Dictionary<IImportType, IImportViewModel>()
        {
            { new FileImportType(), importFromFileViewModel },
        };
    }

    public bool DisplayFileImport
    {
        get => displayFileImport;
        set => NotifyPropertyChanged(ref displayFileImport, value);
    }

    public void SetDisplay()
    {
        DisplayFileImport = false;

        if (configurationModel.ImportType.Name.Equals(new FileImportType().Name))
        {
            DisplayFileImport = true;
        }
    }

    private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(configurationModel.ImportType):
            case nameof(configurationModel.Category):
            case nameof(configurationModel.Flavor):
                SetDisplay();
                break;
        }
    }

}
