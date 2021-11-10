using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;

namespace DataAnalyzer.Models
{
  public class MainModel : BasePropertyChanged
  {
    private LoadedDataContent loadedDataContent = new LoadedDataContent();
    private LoadedDataStructure loadedDataStructure = new LoadedDataStructure();
    private LoadedInputFiles loadedInputFiles = new LoadedInputFiles();

    public MainModel()
    {
    }

    public LoadedDataContent LoadedDataContent
    {
      get => this.loadedDataContent;
      set => this.NotifyPropertyChanged(nameof(this.LoadedDataContent), ref this.loadedDataContent, value);
    }

    public LoadedDataStructure LoadedDataStructure
    {
      get => this.loadedDataStructure;
      set => this.NotifyPropertyChanged(nameof(this.LoadedDataStructure), ref this.loadedDataStructure, value);
    }

    public LoadedInputFiles LoadedInputFiles
    {
      get => this.loadedInputFiles;
      set => this.NotifyPropertyChanged(nameof(this.LoadedInputFiles), ref this.loadedInputFiles, value);
    }
  }
}
