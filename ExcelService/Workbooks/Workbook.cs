using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;
using ExcelService.Worksheets;

namespace ExcelService.Workbooks
{
    public abstract class Workbook : ExcelEntity, IWorkbook
    {
        private Workbook() { }

        public Workbook(
          string filePath,
          ICollection<IWorksheet> worksheets,
          IActionDefinitions workbookActions = null)
        {
            if (!this.IsValidFilePath(filePath))
            {
                string errorMsg = $"Document type of {this.DocumentType} is expected to have file extension" +
                  $" {DocumentTypeUtilities.GetExtension(this.DocumentType)}.";

                throw new System.Exception(errorMsg);
            }

            this.FileName = Path.GetFileNameWithoutExtension(filePath);
            this.FilePath = filePath;
            this.Worksheets = worksheets;

            if (workbookActions != null)
            {
                this.ActionDefinitions = workbookActions;
            }
        }

        public override string Name => "Workbook";

        public string FileName { get; } = string.Empty;

        public string FilePath { get; } = string.Empty;

        public ICollection<IWorksheet> Worksheets { get; } = new List<IWorksheet>();

        public abstract DocumentType DocumentType { get; }

        public bool IsValidFilePath(string filePath)
        {
            return filePath.EndsWith(DocumentTypeUtilities.GetExtension(this.DocumentType));
        }
    }
}
