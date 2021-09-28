using System.Windows;
using System.Windows.Shapes;

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyShapesViewModel model = new MyShapesViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = model;
            this.ic.AddHandler(MouseLeftButtonUpEvent, new RoutedEventHandler(ShapeClicked)); // 订阅 RoutedEvent

        }

        private void ShapeClicked(object sender, RoutedEventArgs e)
        {
            var s = e.OriginalSource as Shape; // 时间最初的 Source
            if (s != null && s.DataContext is MyShapeModel) // 确认是否是需要处理的指定事件
            {
                model.Shape = s.DataContext as MyShapeModel;
            }
        }
    }
}
