using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions;

public abstract class DataAction : IDataAction
{
    public abstract string GetName();

    public abstract string GetDescription();

    public abstract IActionParameters GetDefaultParameters();

    public abstract bool IsApplicable(IActionParameters parameters);

    public abstract bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message);

    public abstract bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message);

    public abstract bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message);

    protected bool IsCorrectType(IActionParameters parameters, Type type)
    {
        return parameters.GetType().Equals(type);
    }
}
