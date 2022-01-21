using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
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
    private readonly ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
    private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;

    private string configurationDirectory = string.Empty;
    private string dataTypeConfigName = string.Empty;

    private readonly BaseCommand browseDirectory;
    private readonly BaseCommand saveDataTypes;

    public ExcelDataTypesViewModel()
    {
      this.excelDataTypeLibrary.GetParameterTypes().ToList().ForEach(x => this.ParameterTypes.Add(x));

      this.browseDirectory = new BaseCommand((obj) => this.DoBrowseDirectory());
      this.saveDataTypes = new BaseCommand((obj) => this.DoSaveDataTypes());

      this.ConfigurationDirectory = this.excelSetupModel.ExcelConfiguration.ConfigurationDirectory;

      this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
      this.excelSetupModel.ExcelConfiguration.PropertyChanged += this.ExcelConfigurationPropertyChanged;
      this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;
    }

    public ObservableCollection<ExcelDataTypeListItemViewModel> SavedConfigurations { get; }
      = new ObservableCollection<ExcelDataTypeListItemViewModel>();

    public ObservableCollection<ITypeParameter> ParameterTypes { get; set; }
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
        this.excelSetupModel.ExcelConfiguration.ConfigurationDirectory = value;
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

      ExcelDataTypesSerialization excelDataTypesSerialization = new ExcelDataTypesSerialization(
        this.ParameterSelections.Select(x => x.SelectedParameterType).ToList(),
        "TODO");

      this.excelSetupModel.ExcelConfiguration.SaveDataTypeConfiguration(excelDataTypesSerialization, this.DataTypeConfigName);
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
            ITypeParameter typeParameter = this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes.DiscreteValue?
              .FirstOrDefault(x => x.DataName.Equals(name));

            if (typeParameter != default)
            {
              this.ParameterSelections.Add(new DataTypeSelectionViewModel(
                typeParameter.DataName,
                this.excelDataTypeLibrary.GetByName(typeParameter.Name),
                typeParameter.GetParameterNameValuePairs()));
            }
            else
            {
              this.ParameterSelections.Add(new DataTypeSelectionViewModel()
              {
                SelectedParameterType = new NoTypeParameter(
                  new GeneralNumericCellDataFormat(),
                  (param) => new GeneralNumericCellDataFormat()),
                DataName = name,
              });
            }

            this.ParameterSelections.Last().StartingSelectedIndex = this.ParameterTypes
                .IndexOf(this.ParameterTypes
                  .First(x => x.Name.Equals(this.ParameterSelections.Last().SelectedParameterType.Name)));
          }

          break;
      }
    }

    private void ExcelConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.excelSetupModel.ExcelConfiguration.DataTypeConfigName):
          this.DataTypeConfigName = this.excelSetupModel.ExcelConfiguration.DataTypeConfigName;
          break;
        case nameof(this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes):
          this.ParameterSelections.Clear();

          this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes.DiscreteValue
            .ForEach(typeParameters => this.ParameterSelections.Add(
              new DataTypeSelectionViewModel(
                typeParameters.DataName,
                this.excelDataTypeLibrary.GetByName(typeParameters.Name),
                typeParameters.GetParameterNameValuePairs()
            )));
          break;
        case nameof(this.excelSetupModel.ExcelConfiguration.DataTypeConfigurationPath):
          break;
        case nameof(this.excelSetupModel.ExcelConfiguration.SavedConfigurations):
          this.SavedConfigurations.Clear();
          this.excelSetupModel.ExcelConfiguration.SavedConfigurations.ToList().ForEach(savedConfig =>
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
