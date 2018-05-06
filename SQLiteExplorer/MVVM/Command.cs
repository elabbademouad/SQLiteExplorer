using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLiteExplorer.MVVM
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _ExecuteMethode;
        Func<object, bool> _CanExecuteMethode;

        public Command(Action<object> Execute,Func<object,bool> CanExecute)
        {
            _ExecuteMethode = Execute;
            _CanExecuteMethode = CanExecute;
        }
        public Command(Action<object> Execute)
        {
            _ExecuteMethode = Execute;
            _CanExecuteMethode = null;
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecuteMethode != null)
                return _CanExecuteMethode(parameter);
            else
                return true;
        }

        public void Execute(object parameter)
        {
            _ExecuteMethode(parameter);
        }
        public void RaiseCanExecute(object o)
        {
            if(CanExecuteChanged!=null)
            CanExecuteChanged(o, EventArgs.Empty);
        }
    }
}
