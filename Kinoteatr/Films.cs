using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteatr
{
    public class Films
    {
        public string name { get; set; }
        public List<Sessions> SessionSource { get; set; }
        public Films()
        {
            SessionSource = new List<Sessions>();

            SessionSource.Add(new Sessions() { SessionTime = "11:30" });
            SessionSource.Add(new Sessions() { SessionTime = "14:25" });
            SessionSource.Add(new Sessions() { SessionTime = "18:00" });
            SessionSource.Add(new Sessions() { SessionTime = "21:45" });
            name = "Классное название фильма";
        }
    }
}
