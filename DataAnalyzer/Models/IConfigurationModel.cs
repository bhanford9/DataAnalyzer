using DataAnalyzer.Common.DataParameters;
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
        IDataConfiguration DataConfiguration { get; set; }
        IDataParameterCollection DataParameterCollection { get; set; }
        string ExecutiveConfigurationDirectory { get; set; }
        string ExecutiveConfigurationName { get; set; }
        IScraperFlavor Flavor { get; set; }
        bool HasLoaded { get; }
        IImportExportKey ImportExportKey { get; set; }
        IImportType ImportType { get; set; }
        string SavedDataFilePath { get; set; }
        ExportType SelectedExportType { get; set; }

        void ApplyConfiguration(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        IFileMap GetFileImportMappings();
        bool LoadConfiguration();
        void SaveConfiguration();
        void UpdateFileImportMappings(IFileMap fileMap);
    }
}