using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels;

internal interface IImportConfigurationViewModel : INotifyPropertyChanged
{
    bool CategoryIsSelectable { get; set; }
    IImportExecutiveCommissioner ExecutiveCommissioner { get; }
    bool FlavorIsSelectable { get; set; }
    IReadOnlyCollection<IImportType> ImportTypes { get; }
    IReadOnlyCollection<IScraperCategory> ScraperCategories { get; }
    IReadOnlyCollection<IScraperFlavor> ScraperFlavors { get; }
    IImportType SelectedImportType { get; set; }
    IScraperCategory SelectedScraperCategory { get; set; }
    IScraperFlavor SelectedScraperFlavor { get; set; }
}