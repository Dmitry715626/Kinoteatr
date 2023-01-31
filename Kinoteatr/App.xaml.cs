﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void SessionBtn_Click(object sender, RoutedEventArgs e)
        {
            Border brd = (Border)((Button)sender).Parent;
            StackPanel stack = (StackPanel)((Border)brd).Parent;
            int PremiereId = 0;
               
            foreach(TextBlock textBlock in ((StackPanel)stack).Children.OfType<TextBlock>())
            {
                if (textBlock.Name == "PremierId")
                    PremiereId = int.Parse(textBlock.Text);
            }

            foreach(Films films in Films.GetPremieresList())
            {
                if(films.PremiereId == PremiereId.ToString())
                {
                    for(int i = 0; i < films.SessionSource.Count; i++)
                    {
                        if (films.SessionSource[i].SessionTime == ((Button)sender).Content.ToString())
                        {
                            Films.SelectedHall = films.Halls[i];
                            new HallSelectionWindow(films.Halls[i]).ShowDialog();
                        }
                    }
                }
            }
        }

        private void PointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Style == this.Resources["BtnPoint"] as Style)
            {
                ((Button)sender).Style = this.Resources["BtnPoint2"] as Style;
            }
            else
            {
                ((Button)sender).Style = this.Resources["BtnPoint"] as Style;
            }

        }

        private void PointBtn_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(RowsPoint rows in Films.SelectedHall.PointsArray)
            {
                foreach(Points point in rows.Columns)
                {
                    if(point.Index == GetIndexPoint(sender))
                        if(point.StyleStatus == false)
                            ((Button)sender).Style = this.Resources["BtnPoint2"] as Style;
                }
            }
        }

        private int GetIndexPoint(object sender)
        {
            return int.Parse(((Button)sender).Content.ToString());
        }
    }
}
