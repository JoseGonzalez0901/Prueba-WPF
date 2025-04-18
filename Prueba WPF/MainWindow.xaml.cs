using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prueba_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Callback(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
            MessageBox.Show("Hello World", "Title", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("Hello World", "Title", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes);
        }
    }
}