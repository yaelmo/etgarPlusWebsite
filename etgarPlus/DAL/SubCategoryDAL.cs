using etgarPlus.Classes;
using etgarPlus.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace etgarPlus.DAL
{
    public class SubCategoryDAL
    {

          public static string s;
          public SqlConnection con;

        public SubCategoryDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            con = new SqlConnection(s);
         }

        public void deleteBikeBySubCategory(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM SubCategoryName WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        internal List<Classes.SubCategory> getAllSubCategory()
        {
            con.Open();
            string sqlString = "select * from SubCategoryName";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Classes.SubCategory> listSubCategory = new List<Classes.SubCategory>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listSubCategory.Add(new Classes.SubCategory((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listSubCategory;
        }
        public String GetSubCategory(int ID)
        {
            con.Open();
            string sqlString = "select SubCategoryName from SubCategoryName p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String SubCategory = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    SubCategory = rdr["SubCategoryName"].ToString();
                }
            }
            con.Close();
            return SubCategory;

        }
		public void AddNeSubCategory(int NewId, string NewSubCategory)
        {
            string sqlString = "INSERT INTO SubCategoryName (Id, SubCategoryName) VALUES (@val1, @val2);";

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewSubCategory);
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

        public int maxIdSubCategory()
        {

            con.Open();
            string sqlString = "select Max(Id) as Id from SubCategoryName;";
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
    }
}