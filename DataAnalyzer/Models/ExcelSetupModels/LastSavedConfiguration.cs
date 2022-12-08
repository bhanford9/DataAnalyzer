using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class LastSavedConfiguration
    {
        public StatType StatType { get; set; }

        public string FilePath { get; set; }
    }
}
