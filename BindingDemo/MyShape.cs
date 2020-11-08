using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BindingDemo
{
    class MyShape : INotifyPropertyChanged
    {
        private static int id = 1;

        public int Id { get; set; } = id++;
        public int Top { get; set; } = id * 10;
        public int Left { get; set; } = id * 10;
        private int r = 100;
        public int R
        {
            get { return r; }
            set
            {
                if (r != value)
                {
                    r = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Brush Stroke { get; set; } = randomColor();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static Brush randomColor()
        {
            Random ran = new Random();
            return new SolidColorBrush(Color.FromRgb((byte)ran.Next(1, 255), (byte)ran.Next(1, 255), (byte)ran.Next(1, 233)));
        }
    }
}
