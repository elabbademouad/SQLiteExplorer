using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLiteExplorer.ViewModel
{
    public class ViewViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ViewViewModel()
        {
            _name = "";
        }

    }
}
