﻿using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels
{
    public class ConfigurationCreationViewModelFixture : BaseFixture
    {
        public ConfigurationCreationViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IStructureExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal Mock<IImportExportKey> MockKey { get; set; }

        internal string ConfigKeyPropName => nameof(this.MockConfigurationModel.Object.ImportExportKey);

        internal PropertyChangedEventArgs ConfigKeyChangeArgs => this.GetNamedEventArgs(this.ConfigKeyPropName);

        internal ConfigurationCreationViewModel ViewModel { get; set; }
    }
}
