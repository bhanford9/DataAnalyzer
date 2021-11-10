using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.LoadedConfigurations
{
  public class LoadedDataStructure : BasePropertyChanged
  {
    private readonly string directoryPathKey = "Directory: ";
    private string directoryPath = "Not set";

    private readonly string structureNameKey = "Name:      ";
    private string structureName = "Not set";

    private readonly string dataTypeKey = "Data Type: ";
    private string dataType = "Not set";

    private readonly string groupingsKey = "Groupings: ";
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
