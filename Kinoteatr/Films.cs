using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Kinoteatr
{
    public class Films
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
        public string AgeRate { get; set; }
        public string Genre { get; set; }
        public string FilmId { get; set; }
        public string PremiereId { get; set; }
        public string Photo { get; set; }

        private static List<Films> PremiereList = new List<Films>();
        public List<Hall> Halls { get; set; }
        public List<Sessions> SessionSource { get; set; }
        public Films()
        {
            Halls = new List<Hall>();
            SessionSource = new List<Sessions>();
        }
        public static List<Films> GetPremieresList()
        {
            return PremiereList;
        }
        public static void GetDataBase()
        {
            SqlCon con = new SqlCon();
            con.Open();

            SqlCommand command = new SqlCommand("SELECT Premiere.id, " +
                "idFilm, " +
                "Film.Name, " +
                "Film.Duration, " +
                "Film.Price, " +
                "Film.[Age rating], " +
                "Film.Photo, " +
                  "Genre.Name, " +
               "Hall.id, " +
               "Hall.NumberHall, " +
               "Hall.CountRows, " +
               "Hall.CountColumns, " +
               "Session.Time, " +
               "Session.FactorPrice " +
               "FROM Premiere " +
               "JOIN Film " +
               "ON Film.id = Premiere.idFilm " +
               "JOIN Hall " +
               "ON Hall.id = Premiere.idHall " +
               "JOIN Session " +
               "ON Session.id = Premiere.idSession " +
               "JOIN Genre " +
               "ON Genre.id = Film.idGenre ", con.GetCon());
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                Films films = new Films();
                Sessions sessions = new Sessions();
                Hall hall = new Hall();

                films.PremiereId = read.GetValue(0).ToString();
                films.FilmId = read.GetValue(1).ToString();
                films.Name = read.GetValue(2).ToString();
                films.Duration = read.GetValue(3).ToString() + " мин.";
                films.Price = read.GetValue(4).ToString();
                films.AgeRate = read.GetValue(5).ToString() + "+";
                films.Photo = System.IO.Directory.GetCurrentDirectory() + @"\Images\" + read.GetValue(6).ToString();
                films.Genre = read.GetValue(7).ToString();

                sessions.SessionTime = read.GetValue(12).ToString();
                sessions.SessionPrice = read.GetValue(13).ToString();
                sessions.SessionCost = "325 рублей";

                hall.idHall = read.GetValue(8).ToString();
                hall.NumberHall = read.GetValue(9).ToString();
                hall.CountRows = read.GetValue(10).ToString();
                hall.CountColumns = read.GetValue(11).ToString();

                MessageBox.Show(films.Name);
                if (AddSessions(films, sessions))
                {
                    films.SessionSource.Add(sessions);
                    films.Halls.Add(hall);


                    PremiereList.Add(films);
                }

            }
            read.Close();
            con.Close();
        }

        private static bool AddSessions(Films newFilm, Sessions sessions)
        {
            foreach (Films films in PremiereList)
            {
                if (films.FilmId == newFilm.FilmId)
                {
                    films.SessionSource.Add(sessions);
                    return false;
                }
            }

            return true;
        }
    }
}
