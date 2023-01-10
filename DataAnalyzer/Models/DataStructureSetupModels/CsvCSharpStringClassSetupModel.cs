using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class CsvCSharpStringClassSetupModel : DataStructureSetupModel<CsvNamesDataConfiguration>
    {
        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
            throw new NotImplementedException();
        }
    }
}
