using Autofac;
using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common;
using DataAnalyzer.DataImport;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataScraper;
using System.Windows;

namespace DataAnalyzer
{
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new();

            //DataScraperContainer.Register(builder);

            ApplicationConfigurationContainer.Register(builder);
            CommonContainer.Register(builder);
            ModelsContainer.Register(builder);
            ViewModelsContainer.Register(builder);
            DataImportContainer.Register(builder);
            ServicesContainer.Register(builder);
            StatConfigurationsContainer.Register(builder);

            this.container = builder.Build();

            // Give access to XAML for DI
            Resolver.Container = container;

            //var result = Resolver.Resolve<IDataStructureSetupViewModelRepository>();

            MainWindow mainWindow = new(container.Resolve<IMainViewModel>());
            mainWindow.Show();
        }
    }
}
