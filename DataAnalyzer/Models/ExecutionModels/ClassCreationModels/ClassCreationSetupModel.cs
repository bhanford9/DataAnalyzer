using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels;

internal class ClassCreationSetupModel : BasePropertyChanged, IClassCreationSetupModel
{
    private string configurationName = string.Empty;
    private readonly IClassCreator classCreator;

    public ClassCreationSetupModel(
        IClassCreationConfigurationModel classCreationConfigModel,
        IClassCreator classCreator)
    {
        this.ClassCreationConfigModel = classCreationConfigModel;
        this.ClassCreationConfigModel.PropertyChanged += ClassCreationConfigModelPropertyChanged;
        this.classCreator = classCreator;
    }

    public IClassCreationConfigurationModel ClassCreationConfigModel { get; }

    public ICollection<IClassData> DataItems { get; } = new List<IClassData>();

    public string ConfigurationName
    {
        get => this.configurationName;
        set => this.NotifyPropertyChanged(ref this.configurationName, value);
    }

    public string GetClassesString(ICollection<IClassData> classes)
    {
        // TODO --> create radio button or combo box for class accessibility
        return string.Join($"{Environment.NewLine}{Environment.NewLine}", classes
            .Select(x => this.classCreator.Create(
                x.Accessibility,
                x.ClassName,
                x.Properties
                    .Select(x => (x.Name, x.SelectedType, x.SelectedAccessibility))
                    .ToList())));
    }

    public void LoadDataFromConfiguration()
    {
        this.DataItems.Clear();

        foreach (var classData in this.ClassCreationConfigModel.ClassesData.Classes)
        {
            DataItems.Add(new ClassData()
            {
                Accessibility = classData.Accessibility,
                ClassName = classData.ClassName,
                Properties = classData.ClassProperties.Properties
                    .Select(property => new PropertyData()
                    {
                        SelectedAccessibility = property.Accessibility,
                        Name = property.Name,
                        SelectedType = property.DataType,
                    })
                    .ToList(),
            });
        }

        this.NotifyPropertyChanged(nameof(this.DataItems));
    }

    private void ClassCreationConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            // TODO --> get this event handler back in place
            case nameof(this.ClassCreationConfigModel.ClassesData):
                this.LoadDataFromConfiguration();
                break;
            case nameof(this.ClassCreationConfigModel.CurrentConfigName):
                this.ConfigurationName = this.ClassCreationConfigModel.CurrentConfigName;
                break;
        }
    }
}
