using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzerTest.Fixtures.ViewModels
{
    public class ConfigurationExecutionViewModelFixture : BaseFixture
    {
        public ConfigurationExecutionViewModelFixture()
        {
        }

        internal IConfigurationModel ConfigurationModel { get; set; }

        internal ConfigurationExecutionViewModel ViewModel { get; set; }
    }
}
