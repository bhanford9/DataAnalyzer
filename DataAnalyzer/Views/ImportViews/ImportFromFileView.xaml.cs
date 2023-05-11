using DataAnalyzer.ViewModels.ImportViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ImportViews;

public partial class ImportFromFileView : UserControl
{
    public ImportFromFileView() : this(Resolver.Resolve<IImportFromFileViewModel>()) { }

    internal ImportFromFileView(IImportFromFileViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
}
