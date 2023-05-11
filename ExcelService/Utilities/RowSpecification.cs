namespace ExcelService.Utilities;

public class RowSpecification : IRowSpecification
{
    public int NthRow { get; set; }

    public bool AllRows { get; set; } = true;

    public bool UseNthRow { get; set; } = false;
}
