using Autofac;
using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common;
using DataAnalyzer.DataImport;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels;
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

            DataScraperContainer.Register(builder);

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

            // Give solution wide access to DI Resolution
            DependencyInjectionUtilities.Resolver.Container = container;

            MainWindow mainWindow = new(container.Resolve<IMainViewModel>());
            mainWindow.Show();
        }
    }
}
