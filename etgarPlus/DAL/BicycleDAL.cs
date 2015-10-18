using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using System.Diagnostics;

//MessageBox.Show
namespace etgarPlus
{
    public class BicycleDAL
    {

        public static string s;
        public SqlConnection con;

        public BicycleDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            con = new SqlConnection(s); 
        }
        public void AddNewBike(int NewId, int NewMainCategoryId, int NewSubCategoryId, int NewName, int Newsize,
            string NewSpecification, int NewcolorId, Double NewRetailPrice, Double NewRegularPrice, Double NewClubPrice,
            int NewQuantity, String imagePath, String Model)
        {

            string sqlString = "INSERT INTO Bicycle (Id, MainCategory, SubCategory, Name, size, Specification, color, RetailPrice, " +
           "RegularPrice, ClubPrice, Quantity, Image, Model) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9," +
           "@val10, @val11, @val12, @val13);";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewMainCategoryId);
                comm.Parameters.AddWithValue("@val3", NewSubCategoryId);
                comm.Parameters.AddWithValue("@val4", NewName);
                comm.Parameters.AddWithValue("@val5", Newsize);
                comm.Parameters.AddWithValue("@val6", NewSpecification);
                comm.Parameters.AddWithValue("@val7", NewcolorId);
                comm.Parameters.AddWithValue("@val8", NewRetailPrice);
                comm.Parameters.AddWithValue("@val9", NewRegularPrice);
                comm.Parameters.AddWithValue("@val10", NewClubPrice);
                comm.Parameters.AddWithValue("@val11", NewQuantity);
                comm.Parameters.AddWithValue("@val12", imagePath);
                comm.Parameters.AddWithValue("@val13", Model);

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
        public void updateBikeById(int Id, int MainCategoryId, int SubCategoryId, string Name, int size,
         string Specification, int colorId, float RetailPrice, float RegularPrice, float ClubPrice, int Quantity)
        {
            con.Open();

            con.Close();
        }

        public void deleteBikeById(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM Bicycle WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Bicycles> getAllBike()
        {
            con.Open();
            string sqlString = "select * from Bicycle";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public Bicycles getBikeById(int Id)
        {
            con.Open();
            string sqlString = "select * from Bicycle b where b.Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            Bicycles Bike = null;
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Bike = (new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return Bike;
        }

        public List<Bicycles> getBikeByName(String Name)
        {
            con.Open();
            string sqlString = "select b.Id, b.MainCategory, b.SubCategory, b.Name, b.size, b.Specification," +
           "b.color, b.RetailPrice, b.RegularPrice, b.ClubPrice, b.Quantity, b.Image, b.Model" +
           "from Bicycle b, ProducerID p where b.Name = p.Id AND p.Producer = " + Name + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> getBikeByMainCategory(String MainCategory)
        {
            con.Open();
            string sqlString = "select b.Id, b.MainCategory, b.SubCategory, b.Name, b.size, b.Specification," +
            "b.color, b.RetailPrice, b.RegularPrice, b.ClubPrice, b.Quantity, b.Image, b.Model" +
            "from Bicycle b, MainCategoryID m where b.MainCategory = m.Id AND m.CategoryName = " + MainCategory + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> sortBikeByName()
        {
            con.Open();
            string sqlString = "select * from Bicycle b order by b.Name;";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> sortBikeByMainCategory()
        {
            con.Open();
            string sqlString = "select * from Bicycle b order by b.MainCategory ;";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> sortBikeBySubCategory()
        {
            con.Open();
            string sqlString = "select * from Bicycle b order by b.SubCategory ;";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> sortBikeBySize()
        {
            con.Open();
            string sqlString = "select * from Bicycle b order by b.Size ;";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> getBetweenSizes(int min, int max)
        {
            con.Open();
            string sqlString = "select * from Bicycle b where b.size >= " + min + " AND b.size <= " + max + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }

        public List<Bicycles> getBikeByColor(string color)
        {
            con.Open();
            string sqlString = "select b.Id, b.MainCategory, b.SubCategory, b.Name, b.size, b.Specification,"+
            "b.color, b.RetailPrice, b.RegularPrice, b.ClubPrice, b.Quantity, b.Image, b.Model"+
            "from Bicycle b, ColorsID c where c.Color = "+ color+" AND b.color = c.Id ;";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }
        public List<Bicycles> getBetweenLevelPrice(int LevelPrice, int minPrice, int maxPrice)
        {
            con.Open();
            string sqlString;
            if (LevelPrice <= 3)
            {
                sqlString = "select * from Bicycle b where b.RetailPrice >= " + minPrice + "AND b.RetailPrice <= " + maxPrice + ";";
            }
            else if (LevelPrice == 4)
            {
                sqlString = "select * from Bicycle b where b.RegularPrice >= " + minPrice + "AND b.RegularPrice <= " + maxPrice + ";";
            }
            else
            {
                sqlString = "select * from Bicycle b where b.ClubPrice >= " + minPrice + "AND b.ClubPrice <= " + maxPrice + ";";
            }
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Bicycles> listBicycle = new List<Bicycles>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listBicycle.Add(new Bicycles(Convert.ToInt32(rdr["Id"]), Convert.ToInt32(rdr["MainCategory"]), Convert.ToInt32(rdr["SubCategory"]), Convert.ToInt32(rdr["Name"]), rdr["Model"].ToString(), Convert.ToInt32(rdr["size"]),
                        rdr["Specification"].ToString(), Convert.ToInt32(rdr["color"]), Convert.ToDouble(rdr["RetailPrice"]), Convert.ToDouble(rdr["RegularPrice"]), Convert.ToDouble(rdr["ClubPrice"]), Convert.ToInt32(rdr["Quantity"]), rdr["Image"].ToString()));
                }
            }
            con.Close();
            return listBicycle;
        }
		public int maxIdBike()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from Bicycle;";
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
