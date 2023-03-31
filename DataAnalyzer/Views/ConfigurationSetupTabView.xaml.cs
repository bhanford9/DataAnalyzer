using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ConfigurationSetupTabView : UserControl
    {
        public ConfigurationSetupTabView() : this(Resolver.Resolve<IConfigurationExecutionViewModel>()) { }

        internal ConfigurationSetupTabView(IConfigurationExecutionViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
