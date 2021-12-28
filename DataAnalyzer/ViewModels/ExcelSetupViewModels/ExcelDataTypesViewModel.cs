using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Services.Serializations;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using ExcelService.CellDataFormats.NumericFormat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ExcelDataTypesViewModel : BasePropertyChanged
  {
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
    private readonly ExcelConfigurationModel excelConfigurationModel = BaseSingleton<ExcelConfigurationModel>.Instance;
    private readonly ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
    private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;

    private string configurationDirectory = string.Empty;
    private string dataTypeConfigName = string.Empty;

    private readonly BaseCommand browseDirectory;
    private readonly BaseCommand saveDataTypes;

    public ExcelDataTypesViewModel()
    {
      this.excelDataTypeLibrary.GetParameterTypes().ToList().ForEach(x => this.ParameterTypes.Add(x));

      this.browseDirectory = new BaseCommand((obj) => this.DoBrowseDirectory());
      this.saveDataTypes = new BaseCommand((obj) => this.DoSaveDataTypes());

      this.ConfigurationDirectory = this.excelConfigurationModel.ConfigurationDirectory;

      this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
      this.excelConfigurationModel.PropertyChanged += this.ExcelConfigurationModelPropertyChanged;
      this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;
    }

    public ObservableCollection<ExcelDataTypeListItemViewModel> SavedConfigurations { get; }
      = new ObservableCollection<ExcelDataTypeListItemViewModel>();

    public ObservableCollection<ITypeParameter> ParameterTypes { get; }
      = new ObservableCollection<ITypeParameter>();

    public ObservableCollection<DataTypeSelectionViewModel> ParameterSelections { get; }
      = new ObservableCollection<DataTypeSelectionViewModel>();

    public ICommand BrowseDirectory => this.browseDirectory;
    public ICommand SaveDataTypes => this.saveDataTypes;

    public string ConfigurationDirectory
    {
      get => this.configurationDirectory;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationDirectory), ref this.configurationDirectory, value);
        this.excelConfigurationModel.ConfigurationDirectory = value;
      }
    }

    public string DataTypeConfigName
    {
      get => this.dataTypeConfigName;
      set => this.NotifyPropertyChanged(nameof(this.DataTypeConfigName), ref this.dataTypeConfigName, value);
    }

    private void DoBrowseDirectory()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        this.ApplyConfigurationDirectory(folderBrowserDialog.SelectedPath);
      }
    }

    private void DoSaveDataTypes()
    {
      if (string.IsNullOrEmpty(this.DataTypeConfigName))
      {
        // TODO --> notify name cannot be blank
        return;
      }

      if (this.SavedConfigurations.Any(x => x.Value.Equals(this.DataTypeConfigName)))
      {
        // TODO --> verify overwrite existing configuration
      }

      SerializationCollection serializationCollection = new SerializationCollection()
      {
        Serializations = this.ParameterSelections.Select(x => x.SelectedParameterType.ToSerializable()).ToList()
      };

      this.excelConfigurationModel.SaveDataTypeConfiguration(serializationCollection, this.DataTypeConfigName);
    }

    private void ApplyConfigurationDirectory(string file)
    {
      if (Directory.Exists(file))
      {
        this.ConfigurationDirectory = file;
        List<string> configFiles = Directory.GetFiles(file).ToList();
        this.SavedConfigurations.Clear();

        configFiles.ForEach(configFilePath =>
        {
          string configFile = Path.GetFileName(configFilePath);
          string displayText = configFile;
          while (displayText.Contains("."))
          {
            displayText = Path.GetFileNameWithoutExtension(displayText);
          }

          this.SavedConfigurations.Add(new ExcelDataTypeListItemViewModel() { Value = displayText, ToolTipText = configFile });
        });
      }
    }

    private void LoadDataTypesFromConfig()
    {
    }

    private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.statsModel.StatNames):
          this.ParameterSelections.Clear();

          foreach (string name in this.statsModel.StatNames)
          {
            TypeParameterSerialization typeParamSerialization = this.excelConfigurationModel.LoadedParameterTypes
              .Select(x => x.As<TypeParameterSerialization>())
              .FirstOrDefault(x => x.DataName.Equals(name));

            if (typeParamSerialization != default)
            {
              this.ParameterSelections.Add(new DataTypeSelectionViewModel(
                typeParamSerialization.DataName,
                this.excelDataTypeLibrary.GetByName(typeParamSerialization.Name),
                typeParamSerialization.GetParameterNameValuePairs()));
            }
            else
            {
              this.ParameterSelections.Add(new DataTypeSelectionViewModel()
              {
                DataName = name,
                SelectedParameterType = new NoTypeParameter(
                  new GeneralNumericCellDataFormat(),
                  (param) => new GeneralNumericCellDataFormat()),
              });
            }

            this.ParameterSelections.Last().StartingSelectedIndex = this.ParameterTypes
              .IndexOf(this.ParameterTypes
                .First(x => x.Name.Equals(this.ParameterSelections.Last().SelectedParameterType.Name)));
          }
          break;
      }
    }

    private void ExcelConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.excelConfigurationModel.ConfigurationName):
          this.DataTypeConfigName = this.excelConfigurationModel.ConfigurationName;
          break;
        case nameof(this.excelConfigurationModel.LoadedParameterTypes):
          this.ParameterSelections.Clear();

          this.excelConfigurationModel.LoadedParameterTypes
            .Select(x => x.As<TypeParameterSerialization>())
            .ToList()
            .ForEach(typeParameters => this.ParameterSelections.Add(
              new DataTypeSelectionViewModel(
                typeParameters.DataName,
                this.excelDataTypeLibrary.GetByName(typeParameters.Name),
                typeParameters.GetParameterNameValuePairs()
            )));
          break;
        case nameof(this.excelConfigurationModel.DataTypeConfigurationPath):
          break;
        case nameof(this.excelConfigurationModel.SavedConfigurations):
          this.SavedConfigurations.Clear();
          this.excelConfigurationModel.SavedConfigurations.ToList().ForEach(savedConfig =>
          {
            this.SavedConfigurations.Add(new ExcelDataTypeListItemViewModel()
            {
              IsRemovable = true,
              Value = savedConfig.FileName,
              ToolTipText = savedConfig.FilePath
            });
          });
          break;
      }
    }

    private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationCreationModel.SelectedDataType):
          break;
      }
    }
  }
}
