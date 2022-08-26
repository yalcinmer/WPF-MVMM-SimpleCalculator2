using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVMM_ICommand5.Commands
{
    public class RelayCommand : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;
        bool _canExecuteChanged;
        public RelayCommand(Action<object> execute) : this(execute, null, false) { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute, bool canExecuteChanged)
        {
            _execute = execute;
            _canExecute = canExecute;
            _canExecuteChanged = canExecuteChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> _execute;
        Func<T, bool> _canExecute;
        bool _canExecuteChanged;
        public RelayCommand(Action<T> execute) : this(execute, null, false) { }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute, bool canExecuteChanged)
        {
            _execute = execute;
            _canExecute = canExecute;
            _canExecuteChanged = canExecuteChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(T parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }

        public void Execute(T parameter)
        {
            _execute(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if(parameter == null) return true;
            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T) parameter);
        }
    }
}
