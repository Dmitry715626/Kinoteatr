using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void SessionBtn_Click(object sender, RoutedEventArgs e)
        {
            new HallSelectionWindow().ShowDialog();

            
            MessageBox.Show(((Button)sender).Content.ToString());
        }
    }
}
