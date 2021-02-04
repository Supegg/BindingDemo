using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BindingDemo
{
    class MyShapesViewModel : INotifyPropertyChanged
    {
        private MyShapeModel shape;
        public MyShapeModel Shape
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
        public ObservableCollection<MyShapeModel> MyShapes { get; } = new ObservableCollection<MyShapeModel>();

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new AddCommand(i => true, AddShape));

        private void AddShape(object obj)
        {
            shape = new MyShapeModel();
            MyShapes.Add(shape);
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new RemoveCommand(i => true, RemoveShape));

        private void RemoveShape(object obj)
        {
            if (Shape != null)
            {
                MyShapes.Remove(Shape);
                Shape = null;
            }
        }
        private ICommand increaseCommand;
        public ICommand IncreaseCommand => increaseCommand ?? (increaseCommand = new AddCommand(i => true, IncreaseRadius));

        private void IncreaseRadius(object obj)
        {
            if (Shape != null)
            {
                Shape.Radius += 10;
            }
        }

        private ICommand reduceCommand;

        public ICommand ReduceCommand => reduceCommand ?? (reduceCommand = new AddCommand(i => true, ReduceRadius));

        private void ReduceRadius(object obj)
        {
            if (Shape != null)
            {
                if (Shape.Radius > 10)
                {
                    Shape.Radius -= 10;
                }
            }
        }
        #endregion
    }
}
