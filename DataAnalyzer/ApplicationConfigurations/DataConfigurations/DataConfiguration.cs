﻿using DataAnalyzer.Services;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class DataConfiguration : VersionedConfiguration, IDataConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public IImportExecutionKey ImportExecutionKey { get; set; } = Services.ImportExecutionKey.Default;

        public string SavedDataFilePath { get; set; } = string.Empty;
    }
}
