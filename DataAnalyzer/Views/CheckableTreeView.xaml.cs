using System.Windows.Controls;
using DataAnalyzer.ViewModels;

namespace DataAnalyzer.Views
{
  public partial class CheckableTreeView : UserControl
  {
    private readonly CheckableTreeViewItem viewModel = new CheckableTreeViewItem();

    public CheckableTreeView()
    {
      this.InitializeComponent();
      this.DataContext = this.viewModel;
    }
  }
}
