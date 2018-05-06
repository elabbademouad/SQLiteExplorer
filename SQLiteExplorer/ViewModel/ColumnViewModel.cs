using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLiteExplorer.ViewModel
{
    public class ColumnViewModel
    {
        #region Privates
        private string _name;
        private string _description;
        private bool _isPremaryKey;
        private bool _isForeignKey;
        #endregion
        #region Properties
        public bool IsForeignKey
        {
            get { return _isForeignKey; }
            set { _isForeignKey = value; }
        }
        public bool IsPrimaryKey
        {
            get { return _isPremaryKey; }
            set { _isPremaryKey = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        public ColumnViewModel()
        {
            _name = "";
            _description = "";
            _isPremaryKey = false;
        }
        public override string ToString()
        {
            return Name+" "+Description;
        }
    }
}
