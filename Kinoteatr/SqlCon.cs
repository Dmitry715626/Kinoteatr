using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kinoteatr
{
    public class SqlCon
    {
        public static string path = @"Data Source=DESKTOP-D5J304P\SQLEXPRESS;Initial Catalog=Kino;Integrated Security=True";
        SqlConnection con = new SqlConnection(path);

        public void Open()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void Close()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

        public SqlConnection GetCon()
        {
            return con;
        }
    }
}
