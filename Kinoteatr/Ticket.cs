using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteatr
{
    public class Ticket
    {
        public string FilmName { get; set; }
        public string FilmDuration { get; set; }
        public string FilmSessionTime { get; set; }
        public string TicketPrice { get; set; }
        public string HallNumber { get; set; }
        public string HallPoints { get; set; }
        public static List<Ticket> tickets = new List<Ticket>();

        public static void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
    }
}
