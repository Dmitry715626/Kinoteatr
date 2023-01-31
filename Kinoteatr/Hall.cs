using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteatr
{
    public class Hall
    {
        public string idHall { get; set; }
        public string NumberHall { get; set; }
        public string CountRows { get; set; }
        public string CountColumns { get; set; }
        public List<Points> Points { get; set; }

        public void FillPoints()
        {
            int PointCount = int.Parse(CountColumns) * int.Parse(CountRows);
            Points = new List<Points>();

            for (int i = 0; i < PointCount; i++)
            {
                Points.Add(new Points() { Index = i, StyleStatus = true});;
            }
        }
    }
}
