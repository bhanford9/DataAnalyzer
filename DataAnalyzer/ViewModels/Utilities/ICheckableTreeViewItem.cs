using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface ICheckableTreeViewItem : INotifyPropertyChanged
    {
        ObservableCollection<ICheckableTreeViewItem> Children { get; }
        bool IsChecked { get; set; }
        bool IsLeaf { get; set; }
        string Name { get; set; }
        string Path { get; set; }
    }
}