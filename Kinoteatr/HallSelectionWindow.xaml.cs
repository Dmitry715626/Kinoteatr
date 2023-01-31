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
        public static TextBlock Cost = new TextBlock();
        public static double Price;
        Sessions session = new Sessions();
        Hall hall;
        List<Points> points = new List<Points>();
        Ticket ticket = new Ticket();
        public HallSelectionWindow(Hall hall, Sessions sessions, Films film)
        {
            InitializeComponent();
            ListPoints.ItemsSource = hall.PointsArray;
            this.hall = hall;
            this.session = sessions;
            ticket.FilmName = film.Name;
            ticket.FilmDuration = film.Duration;
            ticket.HallNumber = hall.NumberHall;
            ticket.FilmSessionTime = sessions.SessionTime;
            Cost = LastCost;
            Price = double.Parse(session.SessionCost.Replace(" рублей", ""));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (RowsPoint rows in hall.PointsArray)
            {
                foreach (Points point in rows.Columns)
                {
                    if (point.StyleStatus == false)
                    {
                        points.Add(point);
                    }
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                ticket.HallPoints += points[i].Index;
                if (points.Count > 1 && i != points.Count - 1)
                    ticket.HallPoints += ", ";
            }

            ticket.TicketPrice = (int.Parse(session.SessionCost.Replace(" рублей", "")) * points.Count).ToString();
            Ticket.AddTicket(ticket);
            MessageBox.Show("Билет на " + points.Count + " мест(а) успешно приобретен!", "Info");
            App.TicketSelect = 0;
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.TicketSelect = 0;
            foreach (RowsPoint rows in hall.PointsArray)
            {
                foreach (Points point in rows.Columns)
                {
                    if (point.StyleStatus == false)
                        point.StyleStatus = true;
                }
            }
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("asd");
        }
    }
}
