using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BindingDemo
{
    public sealed class MyShape : Shape
    {
        public Double Radius
        {
            get { return (Double)this.GetValue(RadiusProperty); }
            set
            {
                this.SetValue(RadiusProperty, value);
            }
        }
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
          "Radius", typeof(Double), typeof(MyShape), new PropertyMetadata(100.0)
          {
              PropertyChangedCallback = OnDpChanged
          });


        private static void OnDpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                // do something
            }

            // This method calls InvalidateArrange internally. 
            // After the invalidation, the element will have its layout updated, 
            // which will occur asynchronously unless subsequently forced by UpdateLayout().
            ((MyShape)d).InvalidateVisual();
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                return new EllipseGeometry(new Point(0, 0), this.Radius, this.Radius);
            }
        }
    }
}
