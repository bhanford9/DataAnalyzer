namespace ExcelService.Utilities
{
    internal class ColumnRowSpecification
    {
        public IRowSpecification RowSpecification { get; set; } = new RowSpecification();

        public IColumnSpecification ColumnSpecification { get; set; } = new ColumnSpecification();
    }
}
