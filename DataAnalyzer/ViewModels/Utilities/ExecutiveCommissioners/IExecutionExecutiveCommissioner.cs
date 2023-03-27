namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal interface IExecutionExecutiveCommissioner
    {
        bool DisplayClassCreation { get; set; }
        bool DisplayExcelCreation { get; set; }
        bool DisplayNotSupported { get; set; }

        void ClearDisplays();
        void SetDisplay();
    }
}