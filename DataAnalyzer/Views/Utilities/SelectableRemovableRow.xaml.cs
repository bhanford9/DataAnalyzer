using DataAnalyzer.ViewModels.Utilities;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataAnalyzer.Views.Utilities
{
    public partial class SelectableRemovableRow : UserControl
    {
        private readonly SelectableRemoveableRowViewModel viewModel = new SelectableRemoveableRowViewModel();

        //public static readonly DependencyProperty OnSelectProperty =
        //  DependencyProperty.Register("OnSelect", typeof(ICommand), typeof(SelectableRemoveableRowViewModel));

        public SelectableRemovableRow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }

        //public ICommand OnSelect
        //{
        //  get { return (ICommand)GetValue(OnSelectProperty); }
        //  set { SetValue(OnSelectProperty, value); }
        //}

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.viewModel.Select.Execute(sender);
        }
    }
}
