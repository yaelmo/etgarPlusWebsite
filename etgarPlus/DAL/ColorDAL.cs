using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using System.Diagnostics;

namespace etgarPlus.DAL
{
    public class ColorDAL
    {
        public static string s;
        public SqlConnection con;
        public ColorDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }

        public void deleteBikeByColor(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM ColorsID WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
		public int maxIdColor()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from ColorsID;";
            SqlCommand com = new SqlCommand(sqlString, con);
            int maxId = 0;
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    maxId = Convert.ToInt32(rdr["Id"]);
                }
            }

            con.Close();
            return maxId;
        }
        public void AddNeColor(int NewId, string NewColor){
             string sqlString = "INSERT INTO ColorsID (Id, Color) VALUES (@val1, @val2);";

             using (SqlCommand comm = new SqlCommand())
             {
                 comm.Connection = con;
                 comm.CommandText = sqlString;
                 comm.Parameters.AddWithValue("@val1", NewId);
                 comm.Parameters.AddWithValue("@val2", NewColor);
                 try
                 {
                     con.Open();
                     comm.ExecuteNonQuery();
                     con.Close();
                 }
                 catch (SqlException e)
                 {
                     Debug.WriteLine("error: " + e.Errors);
                 }

             }
        }
        public List<Color> getAllColor()
        {
            con.Open();
            string sqlString = "select * from ColorsID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Color> listColor = new List<Color>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                     listColor.Add(new Color((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listColor;
        }

        public String GetColor(int ID)
        {
            con.Open();
            string sqlString = "select Color from ColorsId p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String color = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    color = rdr["Color"].ToString();
                }
            }
            con.Close();
            return color;

        }

		public int GetId(string color)
        {
            con.Open();
            string sqlString = "select Id from ColorsId p where p.Color = " + color + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            int id=-1;
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    id = Convert.ToInt32(rdr["Id"]);
                }
            }
            con.Close();
            return id;

        }
    }
}