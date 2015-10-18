using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class SizeDAL
    {
         public static string s;
        public SqlConnection con;
        public SizeDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }

        public void deleteBikeBySize(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM SizeID WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Size> getAllSizes()
        {
            con.Open();
            string sqlString = "select * from SizeID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Classes.Size> listColor = new List<Classes.Size>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listColor.Add(new Classes.Size((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listColor;
        }
		public int maxIdSize()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from SizeID;";
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
        public String GetSize(int ID)
        {
            con.Open();
            string sqlString = "select Size from SizeId p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String size = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    size = rdr["Size"].ToString();
                }
            }
            con.Close();
            return size;
        }
		public void AddNeSize(int NewId, string NewSize)
        {
            string sqlString = "INSERT INTO SizeID (Id, Size) VALUES (@val1, @val2);";

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewSize);
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
    }
}