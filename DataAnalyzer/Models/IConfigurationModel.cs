using DataAnalyzer.Models.ImportModels;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.StatConfigurations;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal interface IConfigurationModel : INotifyPropertyChanged
    {
        IScraperCategory Category { get; set; }
        string ConfigurationDirectory { get; set; }
        string ConfigurationFilePath { get; set; }
        string ConfigurationName { get; set; }
        IStatsConfiguration DataConfiguration { get; set; }
        //IDataParameterCollection DataAccessorCollection { get; set; }
        string ExecutiveConfigurationDirectory { get; set; }
        string ExecutiveConfigurationName { get; set; }
        IScraperFlavor Flavor { get; set; }
        bool HasLoaded { get; }
        IImportExecutionKey ImportExecutionKey { get; set; }
        IImportType ImportType { get; set; }
        string SavedDataFilePath { get; set; }
        ExecutionType SelectedExecutionType { get; set; }

        void ApplyConfiguration(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        bool LoadConfiguration();
        void SaveConfiguration();
    }
}