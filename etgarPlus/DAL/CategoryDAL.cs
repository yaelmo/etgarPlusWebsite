using etgarPlus.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class CategoryDAL
    {

        public static string s;
        public SqlConnection con;
        public CategoryDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }

        public void deleteBikeByCategory(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM MainCategoryID WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Category> getAllSizes()
        {
            con.Open();
            string sqlString = "select * from MainCategoryID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Classes.Category> listCategory = new List<Classes.Category>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listCategory.Add(new Classes.Category((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listCategory;
        }
		public int maxIdCategory()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from MainCategoryID;";
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
        public String GetCategory(int ID)
        {
            con.Open();
            string sqlString = "select CategoryName from MainCategoryID p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String category = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    category = rdr["CategoryName"].ToString();
                }
            }
            con.Close();
            return category;
        }
		public void AddNeColor(int NewId, string NewCategory)
        {
            string sqlString = "INSERT INTO MainCategoryID (Id, CategoryName) VALUES (@val1, @val2);";

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewCategory);
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