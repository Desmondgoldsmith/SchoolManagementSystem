using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace KingDessySchool.cs
{
    class omagaconnections
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B22ALD5;Initial Catalog=DessySoft;Integrated Security=True");

        public void opencon()
        {

            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }


        public void closeCon()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }


        public SqlConnection returnCon()
        {
            return con;
        }
    }
}


