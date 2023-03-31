using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.LoadedConfigurations
{
    internal class LoadedDataStructure : BasePropertyChanged, ILoadedDataStructure
    {
        private readonly string directoryPathKey = "Directory:   ";
        private string directoryPath = "Not set";

        private readonly string structureNameKey = "ExcelTypeName:        ";
        private string structureName = "Not set";

        private readonly string dataTypeKey = "Data TypeParameter:   ";
        private string dataType = "Not set";

        private readonly string exportTypeKey = "Export TypeParameter: ";
        private string exportType = "Not set";

        private readonly string groupingsKey = "Groupings:   ";
        private int groupingsCount = 0;

        public string Name => "Data Structure";

        public string DirectoryPathKey => this.directoryPathKey;
        public string DirectoryPathKeyValue => this.directoryPathKey + this.directoryPath;
        public string DirectoryPath
        {
            get => this.directoryPath;
            set
            {
                if (this.directoryPath != value)
                {
                    this.directoryPath = value;
                    this.NotifyPropertyChanged(nameof(this.DirectoryPathKeyValue));
                }
            }
        }

        public string StructureNameKey => this.structureNameKey;
        public string StructureNameKeyValue => this.structureNameKey + this.structureName;
        public string StructureName
        {
            get => this.structureName;
            set
            {
                if (this.structureName != value)
                {
                    this.structureName = value;
                    this.NotifyPropertyChanged(nameof(this.StructureNameKeyValue));
                }
            }
        }

        public string DataTypeKey => this.dataTypeKey;
        public string DataTypeKeyValue => this.dataTypeKey + this.dataType;
        public string DataType // TODO --> this should be import/category/flavor
        {
            get => this.dataType;
            set
            {
                if (this.dataType != value)
                {
                    this.dataType = value;
                    this.NotifyPropertyChanged(nameof(this.DataTypeKeyValue));
                }
            }
        }

        public string ExportTypeKey => this.exportTypeKey;
        public string ExportTypeKeyValue => this.exportTypeKey + this.exportType;
        public string ExportType
        {
            get => this.exportType;
            set
            {
                if (this.exportType != value)
                {
                    this.exportType = value;
                    this.NotifyPropertyChanged(nameof(this.ExportTypeKeyValue));
                }
            }
        }

        public string GroupingsKey => this.groupingsKey;
        public string GroupingsKeyValue => this.groupingsKey + this.groupingsCount;
        public int GroupingsCount
        {
            get => this.groupingsCount;
            set
            {
                if (this.groupingsCount != value)
                {
                    this.groupingsCount = value;
                    this.NotifyPropertyChanged(nameof(this.GroupingsKeyValue));
                }
            }
        }
    }
}
