namespace ExcelService.Utilities
{
    public interface IRowSpecification
    {
        bool AllRows { get; set; }
        bool UseNthRow { get; }
        int NthRow { get; set; }
    }
}
