namespace SQLiteExplorer.ViewModel
{
    class MainWindowViewModel
    {
        private ObjectExplorerViewModel _objectExplorer;

        public ObjectExplorerViewModel ObjectExplorer
        {
            get { return _objectExplorer; }
            set { _objectExplorer = value; }
        }
        public MainWindowViewModel()
        {
            _objectExplorer = new ObjectExplorerViewModel();
        }

    }
}
