using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels
{
    internal class ClassCreationSetupModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

        private string configurationName = string.Empty;

        public ClassCreationSetupModel()
        {
            this.ClassCreationConfigModel.PropertyChanged += ClassCreationConfigModelPropertyChanged;
        }

        public ClassCreationConfigurationModel ClassCreationConfigModel => BaseSingleton<ClassCreationConfigurationModel>.Instance;

        public ObservableCollection<PropertyData> DataItems = new();

        public string ConfigurationName
        {
            get => this.configurationName;
            set => this.NotifyPropertyChanged(ref this.configurationName, value);
        }

        public string GetClassString(string className, ICollection<PropertyData> propertyData)
        {
            // TODO --> create radio button or combo box for class accessibility
            ClassCreator classCreator = new ClassCreator(
                "public",
                className,
                propertyData
                    .Select(x => (x.Name, x.SelectedType, x.SelectedAccessibility))
                    .ToList());

            return classCreator.Create();
        }

        public void LoadDataFromConfiguration()
        {
            this.DataItems.Clear();

            foreach (var property in this.ClassCreationConfigModel.ClassProperties.Properties)
            {
                DataItems.Add(new PropertyData()
                {
                    SelectedAccessibility = property.Accessibility,
                    Name = property.Name,
                    SelectedType = property.DataType
                });
            }

            this.NotifyPropertyChanged(nameof(this.DataItems));
        }

        private void ClassCreationConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.ClassCreationConfigModel.ClassProperties):
                    this.LoadDataFromConfiguration();
                    break;
                case nameof(this.ClassCreationConfigModel.CurrentConfigName):
                    this.ConfigurationName = this.ClassCreationConfigModel.CurrentConfigName;
                    break;
            }
        }
    }
}
