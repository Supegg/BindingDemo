using System.Windows;

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
        }
    }
}
