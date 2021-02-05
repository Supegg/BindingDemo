using System;
using System.Windows.Input;

namespace BindingDemo
{
    /// <summary>
    /// a general Command
    /// </summary>
    class SuCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Predicate<object> canExecute;
        private Action<object> execute;

        public SuCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
