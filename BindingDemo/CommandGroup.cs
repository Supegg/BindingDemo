using System;
using System.Windows.Input;

namespace BindingDemo
{
    class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Predicate<object> canExecute;
        private Action<object> execute;

        public AddCommand(Predicate<object> canExecute, Action<object> execute)
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

    class RemoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Predicate<object> canExecute;
        private Action<object> execute;

        public RemoveCommand(Predicate<object> canExecute, Action<object> execute)
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


    class IncreaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Predicate<object> canExecute;
        private Action<object> execute;

        public IncreaseCommand(Predicate<object> canExecute, Action<object> execute)
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


    class ReduceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Predicate<object> canExecute;
        private Action<object> execute;

        public ReduceCommand(Predicate<object> canExecute, Action<object> execute)
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
