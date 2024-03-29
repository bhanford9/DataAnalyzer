﻿using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.ApplicationConfigurations
{
    /// <summary>
    /// Holds the last used state of the application to be serialized and saved to file and loaded in on application startup
    /// </summary>
    internal class ApplicationConfiguration : VersionedConfiguration
    {
        public IImportType SelectedImport { get; set; }

        public IScraperCategory SelectedCategory { get; set; }

        public IScraperFlavor SelectedFlavor { get; set; }

        public ExportType SelectedExport { get; set; }
    }
}