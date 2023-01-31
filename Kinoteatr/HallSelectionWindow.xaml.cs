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
using System.Windows.Shapes;

namespace Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для HallSelectionWindow.xaml
    /// </summary>
    public partial class HallSelectionWindow : Window
    {
        public HallSelectionWindow(Hall hall)
        {
            InitializeComponent();
            ListPoints.ItemsSource = hall.PointsArray;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
