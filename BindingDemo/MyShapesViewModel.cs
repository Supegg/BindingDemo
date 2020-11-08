using Microsoft.VisualStudio.PlatformUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BindingDemo
{
    class MyShapesViewModel : INotifyPropertyChanged
    {
        private MyShape shape;
        public MyShape Shape
        {
            get { return shape; }
            set
            {
                if (!object.ReferenceEquals(shape, value))
                {
                    shape = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region commands
        public ObservableCollection<MyShape> MyShapes { get; } = new ObservableCollection<MyShape>();

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new DelegateCommand(AddShape));

        private void AddShape()
        {
            shape = new MyShape();
            MyShapes.Add(shape);
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new DelegateCommand(RemoveShape));

        private void RemoveShape(object obj)
        {
            if (Shape != null)
            {
                MyShapes.Remove(Shape);
                Shape = null;
            }
        }
        private ICommand increaseCommand;
        public ICommand IncreaseCommand => increaseCommand ?? (increaseCommand = new DelegateCommand(IncreaseRadius));

        private void IncreaseRadius(object obj)
        {
            if (Shape != null)
            {
                Shape.R += 10;
            }
        }

        private ICommand reduceCommand;

        public ICommand ReduceCommand => reduceCommand ?? (reduceCommand = new DelegateCommand(ReduceRadius));

        private void ReduceRadius(object obj)
        {
            if (Shape != null)
            {
                if (Shape.R > 10)
                {
                    Shape.R -= 10;
                }
            }
        }
        #endregion
    }
}
