﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BindingDemo
{
    class MyShapeModel : INotifyPropertyChanged
    {
        private static Random ran = new Random();
        private static int count = 0;

        private int id = 0;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // 通过一定的计算，对应Shape的几何中心
        private double top;
        public double Top
        {
            get { return top; }
            set
            {
                if (top != value)
                {
                    top = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private double left;
        public double Left
        {
            get { return left; }
            set
            {
                if (left != value)
                {
                    left = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MyShapeModel()
        {
            count += 1;
            id = count;
            Top = id * 10 - radius;
            Left = id * 10 - radius;
        }

        private double radius = 100;
        public double Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    Top = id * 10 - radius;
                    Left = id * 10 - radius;
                    NotifyPropertyChanged();
                }
            }
        }
        private int thickness = 10;
        public int Thickness
        {
            get { return thickness; }
            set
            {
                if (thickness != value)
                {
                    thickness = value;
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
            return new SolidColorBrush(Color.FromRgb((byte)ran.Next(1, 255), (byte)ran.Next(1, 255), (byte)ran.Next(1, 233)));
        }
    }
}
