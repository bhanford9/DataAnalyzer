using System;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Services
{
    internal class InputExportKey
    {
        private readonly int hashCode;

        public InputExportKey(ImportKey importKey, ExportType exportType)
        {
            this.ImportKey = importKey;
            this.ExportType = exportType;

            this.hashCode = HashCode.Combine(this.ImportKey, this.ExportType);
        }

        public ImportKey ImportKey { get; private set; }

        public ExportType ExportType { get; private set; }

        public override bool Equals(object obj) => 
            obj is InputExportKey key &&
                ImportKey.Equals(key.ImportKey) &&
                ExportType.Equals(key.ExportType);

        public override int GetHashCode() => this.hashCode;
    }
}
