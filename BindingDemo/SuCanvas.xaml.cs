using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for SuCanvas.xaml
    /// </summary>
    public partial class SuCanvas : UserControl
    {
        private Canvas cvsMain;

        public SuCanvas()
        {
            InitializeComponent();

            // 订阅 RoutedEvent，事件会在控件树上传递，直到被处理
            this.ic.AddHandler(MouseLeftButtonUpEvent, new RoutedEventHandler(ShapeClicked));
        }

        private void ShapeClicked(object sender, RoutedEventArgs e)
        {
            MyShapesViewModel model = this.DataContext as MyShapesViewModel;

            var s = e.OriginalSource as Shape; // 时间最初的 Source
            if (s != null && s.DataContext is MyShapeModel) // 确认是否是需要处理的指定事件
            {
                model.Shape = s.DataContext as MyShapeModel;
            }
        }


        private void cvsMain_Loaded(object sender, RoutedEventArgs e)
        {
            this.cvsMain = sender as Canvas; // 获取Canvas的引用
        }

        #region Canvas transform
        private void translate(double dx, double dy)
        {
            TransformGroup tg = cvsMain.RenderTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
            }
            tg.Children.Add(new TranslateTransform(dx, dy));
            cvsMain.RenderTransform = tg;
        }

        private void scale(double sx, double sy, double cx = 0, double cy = 0)
        {
            TransformGroup tg = cvsMain.RenderTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
            }
            tg.Children.Add(new ScaleTransform(sx, sx, cx, cy));
            cvsMain.RenderTransform = tg;
        }

        private void reset()
        {
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new TranslateTransform(0, 0));
            tg.Children.Add(new ScaleTransform(1, 1));
            cvsMain.RenderTransform = tg;
        }
        #endregion

        #region mouse triggers
        /// <summary>
        /// 平移Canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            var p = e.GetPosition(cvsMain);
            cttPos.Content = $"{p.X.ToString("0")}, {p.Y.ToString("0")}";
        }

        private bool isMoving = false;
        private Point start = new Point();
        private Point end = new Point();
        /// <summary>
        /// 进入move待命状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMoving = true;
            cvsMain.Cursor = Cursors.Hand;

            start = e.GetPosition(bdMain);
        }

        /// <summary>
        /// 处理平移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoving)
            {
                return;
            }

            end = e.GetPosition(bdMain);
            var offset = end - start;
            start = end;

            translate(offset.X, offset.Y);
        }

        /// <summary>
        /// 退出move待命状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdMain_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMoving = false;
            cvsMain.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// 处理缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdMain_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // tbkLog.Text += $"wheel roll Delta: {e.Delta}\r\n";

            // ScaleTransform 中心是显示控件在屏幕尺度上的相对位置
            // Canvas可能发生了Transform，与屏幕尺寸比例可能不一致
            Point c = e.GetPosition(bdMain);
            if (e.Delta > 0)
            {
                scale(1.25, 1.25, c.X, c.Y);
            }
            else
            {
                scale(0.8, 0.8, c.X, c.Y);
            }
        }
        #endregion
    }
}
