using System;

namespace ExcelService.Utilities
{
  public class ColumnConversions
  {
    public const int MAX_COLUMN_COUNT = 16384;

    public static int NameToNumber(string columnName)
    {
      if (string.IsNullOrEmpty(columnName))
      {
        throw new ArgumentNullException("columnName");
      }

      columnName = columnName.ToUpperInvariant();

      int sum = 0;

      for (int i = 0; i < columnName.Length; i++)
      {
        sum *= 26;
        sum += columnName[i] - 'A' + 1;
      }

      return sum;
    }

    public static string NumberToName(int columnNumber)
    {
      if (columnNumber < 1)
      {
        throw new Exception("Column count must be greater than zero.");
      }

      if (columnNumber > MAX_COLUMN_COUNT)
      {
        throw new Exception($"Column count must be less than or equal to {MAX_COLUMN_COUNT}.");
      }

      string columnName = "";

      while (columnNumber > 0)
      {
        int modulo = (columnNumber - 1) % 26;
        columnName = Convert.ToChar('A' + modulo) + columnName;
        columnNumber = (columnNumber - modulo) / 26;
      }

      return columnName;
    }
  }
}
