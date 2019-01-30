using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecuteFunc = null;
        private bool? _CanExecute = null;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._Execute = execute;
            this._CanExecuteFunc = canExecute;
        }

        public RelayCommand(Action<object> execute, bool canExecute)
        {
            this._Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute.HasValue) { return _CanExecute.Value; }

            return _CanExecuteFunc == null || this._CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            this._Execute(parameter);
        }
    }
}