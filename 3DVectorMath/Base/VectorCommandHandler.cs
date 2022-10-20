using System;
using System.Windows.Input;
using VectorLib;

namespace _3DVectorMath.Base
{
    public class VectorCommandHandler : ICommand
    {
        private Action<Vector> _action;
        private bool _canExecute;
        public event EventHandler CanExecuteChanged;

        public VectorCommandHandler(Action<Vector> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter as Vector);
        }
    }
}
