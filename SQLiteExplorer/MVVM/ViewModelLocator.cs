using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SQLiteExplorer;

namespace SQLiteExplorer.MVVM
{
    public static class ViewModelLocator
    {
        static Dictionary<Type, Type> _AdapterCollection;
        static ViewModelLocator()
        {
            _AdapterCollection = new Dictionary<Type, Type>();
            _AdapterCollection.Add(typeof(ViewModel.ObjectExplorerViewModel), typeof(View.ObjectExplorerView));           
        }

        public static Dictionary<Type, Type> AdapterCollection { get { return _AdapterCollection; } set { _AdapterCollection = value; } }
    }
    public class ViewConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Type ViewModel = value.GetType();
                Type ViewType = ViewModelLocator.AdapterCollection.Where(vm => vm.Key == ViewModel).Select(v => v.Value).FirstOrDefault();
                dynamic View = Activator.CreateInstance(ViewType);
                View.DataContext = value;
                return View;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
