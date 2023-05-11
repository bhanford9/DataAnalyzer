namespace ExcelService.Utilities;

internal class ColumnRowSpecification : IColumnRowSpecification
{
    public ColumnRowSpecification() { }
    public ColumnRowSpecification(IRowSpecification row, IColumnSpecification column)
    {
        this.RowSpecification = row;
        this.ColumnSpecification = column;
    }

    public IRowSpecification RowSpecification { get; set; } = new RowSpecification();

    public IColumnSpecification ColumnSpecification { get; set; } = new ColumnSpecification();
}
