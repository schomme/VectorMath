using System;
using System.Windows.Input;
using VectorLib;

namespace _3DVectorMath.Base
{
    public class CommandHandler : ICommand
    {
        private Action<Vector> _action;
        private bool _canExecute;
        public CommandHandler(Action<Vector> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter as Vector);
        }
    }
}
