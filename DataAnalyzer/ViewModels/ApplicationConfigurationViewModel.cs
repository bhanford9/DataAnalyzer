using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels;

internal class ApplicationConfigurationViewModel : BasePropertyChanged, IApplicationConfigurationViewModel
{
    private readonly BaseCommand selectDirectory;
    private readonly BaseCommand apply;

    private string selectedDirectory = string.Empty;
    private string configName = string.Empty;

    private IConfigurationModel configurationModel;

    public ApplicationConfigurationViewModel(IConfigurationModel configurationModel)
    {
        this.configurationModel = configurationModel;
        this.selectDirectory = new BaseCommand(_ => this.DoSelectDirectory());
        this.apply = new BaseCommand(_ => this.DoApply());

        this.SelectedDirectory = this.configurationModel.ConfigurationDirectory;
        this.ConfigName = this.configurationModel.ConfigurationName;
        this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
    }

    public ICommand SelectDirectory => this.selectDirectory;
    public ICommand Apply => this.apply;

    public string SelectedDirectory
    {
        get => this.selectedDirectory;
        set => this.NotifyPropertyChanged(ref this.selectedDirectory, value);
    }

    public string ConfigName
    {
        get => this.configName;
        set => this.NotifyPropertyChanged(ref this.configName, value);
    }

    private void DoSelectDirectory()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            this.SelectedDirectory = folderBrowserDialog.SelectedPath;
        }
    }

    private void DoApply()
    {
        this.configurationModel.ConfigurationDirectory = this.selectedDirectory;
        this.configurationModel.ConfigurationName = this.ConfigName.EndsWith(".json")
            ? this.ConfigName[..^5]
            : this.ConfigName;
    }

    private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(this.configurationModel.ConfigurationDirectory):
                this.SelectedDirectory = this.configurationModel.ConfigurationDirectory;
                break;
            case nameof(this.configurationModel.ConfigurationName):
                this.ConfigName = this.configurationModel.ConfigurationName;
                break;
        }
    }
}
