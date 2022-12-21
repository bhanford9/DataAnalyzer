using System.Collections.ObjectModel;
using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class CheckableTreeViewItem : BasePropertyChanged
    {
        private bool isChecked = true;
        private bool isLeaf = true;
        private string name = string.Empty;
        private string path = string.Empty;

        public CheckableTreeViewItem()
        {
        }

        public ObservableCollection<CheckableTreeViewItem> Children { get; } = new();

        public bool IsChecked
        {
            get => this.isChecked;
            set
            {
                this.NotifyPropertyChanged(ref this.isChecked, value);

                for (int i = 0; i < this.Children.Count; i++)
                {
                    this.Children[i].IsChecked = value;
                }
            }
        }

        public bool IsLeaf
        {
            get => this.isLeaf;
            set => this.NotifyPropertyChanged(ref this.isLeaf, value);
        }

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public string Path
        {
            get => this.path;
            set => this.NotifyPropertyChanged(ref this.path, value);
        }
    }
}
