using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExplorer.ViewModel
{
    public class TableViewModel
    {
        #region privates 
        private string _name;
        private ObservableCollection<ColumnViewModel> _columns;
        private ObservableCollection<ForeignKeyViewModel> _foreignKeys;
        private ObservableCollection<string> _indexs;
        #endregion
        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ObservableCollection<string> Indexs
        {
            get { return _indexs; }
            set { _indexs = value; }
        }

        public ObservableCollection<ForeignKeyViewModel> ForeignKeys
        {
            get { return _foreignKeys; }
            set { _foreignKeys = value; }
        }

        public ObservableCollection<ColumnViewModel> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        #endregion

        public TableViewModel()
        {
            _name = "";
            _columns = new ObservableCollection<ColumnViewModel>();
            _foreignKeys = new ObservableCollection<ForeignKeyViewModel>();
            _indexs = new ObservableCollection<string>();
        }
        
    }
}
