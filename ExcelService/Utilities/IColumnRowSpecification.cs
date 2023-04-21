namespace ExcelService.Utilities
{
    internal interface IColumnRowSpecification
    {
        IColumnSpecification ColumnSpecification { get; set; }
        IRowSpecification RowSpecification { get; set; }
    }
}