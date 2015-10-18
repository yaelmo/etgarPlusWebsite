﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using etgarPlus.Classes;
using System.Configuration;

namespace etgarPlus
{
    public class AccessoriesDAL
    {
         public string s;
        public SqlConnection con;

        public AccessoriesDAL()
        {
           //s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Yael\Dropbox\etgarplus\etgarPlusDB.mdf;Integrated Security=True;Connect Timeout=30";
           //s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\David\Dropbox\etgarPlus\etgarPlusDB.mdf;Integrated Security=True;Connect Timeout=30";
           //s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Talia\Dropbox\etgarplus\etgarPlusDB.mdf;Integrated Security=True;Connect Timeout=30";
           s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
           con = new SqlConnection(s);
            
        }

        public List<Accessories> GetAllAccessories()
        {
            con.Open();
            string sqlString = "select * from Accessories";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public void AddNewAccessory(int Id, string MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            con.Open();

            con.Close();
        }

        public void UpdateAccessory(int Id, string MainCategoryID, string SubCategoryID, string Name, float RetailPrice, float RegularPrice, float ClubPrice)
        {
            con.Open();

            con.Close();
        }

        public void DeleteAccessory(int Id, string Name)
        {
            con.Open();
            string sqlString = @"DELETE FROM Accessories a where a.Id = " + Id + "AND a.Name = " + Name + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Accessories> SortByCategory(int Category)
        {
            con.Open();
            string sqlString = "select * from Accessories a group by a.MainCategoryID";///////////////
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> SortBySubCategory(int sub)
        {
            con.Open();
            string sqlString = "select * from Accessories";///////////////////////////
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> Between2Prices(int LevelPrice, int minPrice, int maxPrice)
        {
            con.Open();
            string sqlString = "select * from Accessories";/////////////////////////
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryByCategory(int CategoryID)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.CategoryID = " + CategoryID + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryBySubCategory(int SubCategoryID)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.SubCategoryID = " + SubCategoryID + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        public List<Accessories> GetAccessoryByName(string Name)
        {
            con.Open();
            string sqlString = "select * from Accessories a where a.Name = " + Name + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Accessories> listAccessories = new List<Accessories>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listAccessories.Add(new Accessories((int)rdr[0], (int)rdr[1], (int)rdr[2], (String)rdr[3],
                        (float)rdr[4], (float)rdr[5], (float)rdr[6]));
                }
            }
            con.Close();
            return listAccessories;
        }

        internal List<Accessories> SortBySubCategory()
        {
            throw new NotImplementedException();
        }

        internal List<Accessories> SortByCategory()
        {
            throw new NotImplementedException();
        }
    }
}