using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BindingDemo
{
    public sealed class MyShape : Shape
    {
        /// <summary>
        /// 自定义依赖属性
        /// 发生变化时重绘视图
        /// </summary>
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
            // this will occur DefiningGeometry
            ((MyShape)d).InvalidateVisual();
        }

        public MyShape()
        {

        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                int id = (int)this.ToolTip;
                Geometry geometry = null;

                switch (id % 3)
                {
                    case 0:
                        geometry = new StreamGeometry();
                        using (StreamGeometryContext ctx = ((StreamGeometry)geometry).Open())
                        {
                            ctx.BeginFigure(new Point(Radius * 5, 50), true, true);
                            ctx.LineTo(new Point(100, Radius * 5), true, false);
                            ctx.LineTo(new Point(Radius * 5, Radius * 5), true, false);
                        }
                        break;
                    case 1:
                        geometry = new RectangleGeometry(new Rect(700, 100, Radius * 2, Radius * 2), Radius * 0.1, Radius * 0.1);
                        break;
                    case 2:
                        geometry = new EllipseGeometry(new Point(100, 50), this.Radius, this.Radius);
                        break;
                }

                return geometry;
            }
        }
    }
}
