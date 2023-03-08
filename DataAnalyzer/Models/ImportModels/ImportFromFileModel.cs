using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.ImportModels
{
    internal class ImportFromFileModel : ImportModel
    {
        private string activeDirectory = "No Directory Selected Yet";

        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        public ImportFromFileModel()
        {
            this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;

            if (this.ActiveDirectory != string.Empty)
            {
                this.ApplyActiveDirectory(this.ActiveDirectory);
            }
        }

        public string ActiveDirectory
        {
            get => this.activeDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.activeDirectory, value);
                this.mainModel.LoadedInputFiles.DirectoryPath = value;
            }
        }

        public void ApplyActiveDirectory(string path)
        {
            this.ActiveDirectory = path;

            Properties.Settings.Default.LastUsedDataDirectory = this.ActiveDirectory;
            Properties.Settings.Default.Save();
        }
    }
}
