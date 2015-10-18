using etgarPlus.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class CityDAL
    {
        public static string s;
        public SqlConnection con;
        public CityDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            con = new SqlConnection(s);
            
        }

        public List<City> getAllCity()
        {
            con.Open();
            string sqlString = "select * from CityID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<City> listCity = new List<City>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listCity.Add(new City((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listCity;
        }

        public String GetCity(int ID)
        {
            con.Open();
            string sqlString = "select Name from CityID p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String city = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    city = rdr["Name"].ToString();
                }
            }
            con.Close();
            return city;

        }
    }
}