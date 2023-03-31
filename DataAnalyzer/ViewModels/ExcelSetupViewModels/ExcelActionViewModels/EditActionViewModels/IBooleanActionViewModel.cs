namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal interface IBooleanActionViewModel : IEditActionViewModel
    {
        bool DoPerform { get; set; }
    }
}