using SQLiteExplorer.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteExplorer.MVVM;
using SQLiteExplorer.Helper;
using System.ComponentModel;
using System.Diagnostics;

namespace SQLiteExplorer.ViewModel
{
    public  class ObjectExplorerViewModel :INotifyPropertyChanged
    {
        private Command _openDataBaseCMD;
        private Command _refreshCMD;
        private Command _openInFolderCMD;
        private Command _removeDataBaseFromHistoryCMD;

        public Command RemoveDataBaseFromHistoryCMD
        {
            get { return _removeDataBaseFromHistoryCMD; }
            set { _removeDataBaseFromHistoryCMD = value; }
        }

        public Command OpenInFolderCMD
        {
            get { return _openInFolderCMD; }
            set { _openInFolderCMD = value; }
        }

        private DataBaseViewModel _selectedDataBase;

        public DataBaseViewModel SelectedDataBase
        {
            get { return _selectedDataBase; }
            set { _selectedDataBase = value;Notify("SelectedDataBase"); }
        }

        public Command RefreshCMD
        {
            get { return _refreshCMD; }
            set { _refreshCMD = value; }
        }

        public Command OpenDataBaseCMD
        {
            get { return _openDataBaseCMD; }
            set { _openDataBaseCMD = value; }
        }

        private ObservableCollection<DataBaseViewModel> _dataBases;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataBaseViewModel> DataBases
        {
            get { return _dataBases; }
            set { _dataBases = value;Notify("DataBases"); }
        }

        public ObjectExplorerViewModel()
        {
            _dataBases = new ObservableCollection<DataBaseViewModel>();
            _openDataBaseCMD = new Command(o=>OpenDataBase());
            _refreshCMD = new Command(o => Refresh());
            _openInFolderCMD = new Command(o => OpenInFolder(o.ToString()));
            _removeDataBaseFromHistoryCMD = new Command(o => RemoveDatabaseFromHistory(o.ToString()));
            List<string> dataBasePath = SQLiteCore.GetDataBasesPaths();
            foreach (var path in dataBasePath)
            {
                _dataBases.Add(DataBaseBuilder.BuildDataBaseObject(path,this));
            }   
        }
        public void Refresh()
        {
            List<string> dataBasePath = SQLiteCore.GetDataBasesPaths();
            DataBases = new ObservableCollection<DataBaseViewModel>();
            foreach (var path in dataBasePath)
            {
                DataBases.Add(DataBaseBuilder.BuildDataBaseObject(path,this));
            }
        }
        public void OpenDataBase()
        {
            var path= Hepler.OpenFile();
            if(!string.IsNullOrEmpty(path))
            {
                string connectionString = string.Format("Data source= {0} ;", path);
                if(SQLiteCore.CheckConnection(connectionString))
                {
                    if (SQLiteCore.AddDataBaseToHistory(path))
                        DataBases.Add(DataBaseBuilder.BuildDataBaseObject(path, this));
                }
                
            }
        }
        public void OpenInFolder(string path)
        {          
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", path));
        }

        public void RemoveDatabaseFromHistory(string path)
        {
            if (SQLiteCore.RemoveDatabaseFromHistory(path))
            {
                Refresh();
            }
        }
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
