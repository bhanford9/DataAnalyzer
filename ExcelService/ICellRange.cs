namespace ExcelService
{
  public interface ICellRange : IExcelEntity
  {
    int StartRowNumber { get; set; }

    int StartColNumber { get; set; }

    int EndRowNumber { get; }

    int EndColNumber { get; }
  }
}
