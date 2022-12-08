using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.LoadedConfigurations
{
    internal class LoadedInputFiles : BasePropertyChanged
    {
        private readonly string directoryPathKey = "Directory: ";
        private string directoryPath = "Not set";

        private readonly string dataTypeKey = "Data TypeParameter: ";
        private string dataType = "Not set";

        public string Name => "Input Files";

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

        public string DataTypeKey => this.dataTypeKey;
        public string DataTypeKeyValue => this.dataTypeKey + this.dataType;
        public string DataType
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
    }
}
