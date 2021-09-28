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

            // this.sc.DataContext = model; // 仅用于显示时，可直接将 Model 赋值到 SuCanvas 上
            this.DataContext = model;
        }
    }
}
