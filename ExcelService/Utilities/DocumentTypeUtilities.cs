using DocumentFormat.OpenXml;

namespace ExcelService.Utilities
{
  public class DocumentTypeUtilities
  {
    public static string GetExtension(DocumentType type)
    {
      return type switch
      {
        DocumentType.Workbook => ".xlsx",
        DocumentType.Template => ".xltx",
        DocumentType.MacroEnabledWorkbook => ".xlsm",
        DocumentType.MacroEnabledTemplate => ".xltm",
        DocumentType.AddIn => ".xlam",
        _ => ".xlsx",
      };
    }

    public static SpreadsheetDocumentType ToSpreadSheetType(DocumentType type)
    {
      return type switch
      {
        DocumentType.Workbook => SpreadsheetDocumentType.Workbook,
        DocumentType.Template => SpreadsheetDocumentType.Template,
        DocumentType.MacroEnabledWorkbook => SpreadsheetDocumentType.MacroEnabledWorkbook,
        DocumentType.MacroEnabledTemplate => SpreadsheetDocumentType.MacroEnabledTemplate,
        DocumentType.AddIn => SpreadsheetDocumentType.AddIn,
        _ => SpreadsheetDocumentType.Workbook,
      };
    }
  }
}
