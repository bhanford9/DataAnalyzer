using DataAnalyzer.Common.Mvvm;
using System.IO;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class FilePathAndNamePair : BasePropertyChanged, IFilePathAndNamePair
    {
        private string filePath = string.Empty;

        public FilePathAndNamePair(string fullPath)
        {
            this.filePath = fullPath;
        }

        public string FilePath
        {
            get => this.filePath;
            set
            {
                if (this.filePath != value)
                {
                    this.filePath = value;
                    this.NotifyPropertyChanged(nameof(this.FilePath));
                    this.NotifyPropertyChanged(nameof(this.FileName));
                }
            }
        }

        public string FileName
        {
            get
            {
                string name = Path.GetFileName(this.filePath);
                return name.Substring(0, name.IndexOf("."));
            }
        }
    }
}
