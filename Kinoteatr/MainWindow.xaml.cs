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

namespace Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Films.GetDataBase();
            ListFilms.ItemsSource = Films.GetPremieresList();
        }
        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            new MyTicketsWindow().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке!");
        }
    }
}
