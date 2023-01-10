using System;

namespace DataAnalyzer.Services
{
    internal class InputExportKey
    {
        private readonly int hashCode;

        public InputExportKey(ScraperType scraperType, ExportType exportType)
        {
            this.InputType = scraperType;
            this.ExportType = exportType;

            this.hashCode = HashCode.Combine(this.InputType, this.ExportType);
        }

        public ScraperType InputType { get; private set; }

        public ExportType ExportType { get; private set; }

        public override bool Equals(object obj) => 
            obj is InputExportKey key &&
                InputType == key.InputType &&
                ExportType == key.ExportType;

        public override int GetHashCode() => this.hashCode;
    }
}
