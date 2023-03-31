using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class CsvCSharpStringClassSetupModel : DataStructureSetupModel<CsvNamesDataConfiguration>, ICsvCSharpStringClassSetupModel
    {
        public CsvCSharpStringClassSetupModel(IConfigurationModel configurationModel) : base(configurationModel)
        {
        }

        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
        }
    }
}
