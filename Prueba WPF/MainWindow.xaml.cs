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
        string selecPort= "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Callback(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();
            connection.SendData(Data_send.Text);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Connection connection = new Connection();

            string selectedPort = (string)ComboBox.SelectedItem;
            if (Connection.IsPortAvailable(selectedPort))
            {
                Connection.Connect(selectedPort);
                MessageBox.Show("Connected to " + selectedPort);
                Indicador.Background = Brushes.Green;
            }
            else
            {
                Indicador.Background = Brushes.Blue;
                MessageBox.Show("Port not available");
            }

        }
        private void Drop_Down(object sender, EventArgs e)
        {
            string[] availablePorts = Connection.GetAvailablePorts();
            ComboBox.Items.Clear();
            foreach (string port in availablePorts)
            {
                ComboBox.Items.Add(port);
            }
        }

    }
}