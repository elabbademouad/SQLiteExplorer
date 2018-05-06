using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExplorer.Helper
{
    public static class Hepler
    {
        public static string OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog().Value==true)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
        public static string NewFile()
        {
            return "";
        }
    }
}
