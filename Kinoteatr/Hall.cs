using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kinoteatr
{
    public class Hall
    {
        public string idHall { get; set; }
        public string NumberHall { get; set; }
        public string CountRows { get; set; }
        public string CountColumns { get; set; }
        public List<RowsPoint> PointsArray { get; set; }

        public void FillPoints()
        {
            PointsArray = new List<RowsPoint>();
            int PointCount = 1;
            for (int i = 1; i <= int.Parse(CountRows); i++)
            {
                List<Points> points = new List<Points>();
                for (int j = 1; j <= int.Parse(CountColumns); j++)
                {
                    points.Add(new Points() { StyleStatus = true, Index = PointCount });
                    PointCount++;
                }
               
                PointsArray.Add(new RowsPoint() { Columns = points});
            }
        }
    }
}
