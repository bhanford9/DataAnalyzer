namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal interface IImportExecutiveCommissioner
    {
        bool DisplayFileImport { get; set; }

        void SetDisplay();
    }
}