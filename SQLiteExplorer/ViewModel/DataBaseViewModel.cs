using SQLiteExplorer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExplorer.ViewModel
{
    public class DataBaseViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<TableViewModel> _tables;
        private ObservableCollection<ViewViewModel> _views;
        private ObservableCollection<TriggerViewModel> _triggers;
        private string _name;
        private bool isSelected;
        private Command _SelectCmd;
        private ObjectExplorerViewModel _parent;
        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Command SelectCmd
        {
            get { return _SelectCmd; }
            set { _SelectCmd = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;Notify("IsSelected"); }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ObservableCollection<TriggerViewModel> Triggers
        {
            get { return _triggers; }
            set { _triggers = value; }
        }

        public ObservableCollection<ViewViewModel> Views
        {
            get { return _views; }
            set { _views = value; }
        }

        public ObservableCollection<TableViewModel> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        public ObjectExplorerViewModel Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
            }
        }

        public DataBaseViewModel(ObjectExplorerViewModel parent)
        {
            Parent = parent;
            _tables = new ObservableCollection<TableViewModel>();
            _views = new ObservableCollection<ViewViewModel>();
            _triggers = new ObservableCollection<TriggerViewModel>();
            SelectCmd = new Command(o => {
                if(parent.SelectedDataBase!=null)
                parent.SelectedDataBase.IsSelected = false;
                this.IsSelected = true;
                parent.SelectedDataBase = this;
            });
        }
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
