using etgarPlus.Classes;
using etgarPlus.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class ProducerDAL
    {
        public static string s;
        public SqlConnection con;

        public ProducerDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }
        public void deleteBikeByProducer(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM ProducerID WHERE Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Classes.Producer> getAllProducer()
        {
            con.Open();
            string sqlString = "select * from ProducerID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Producer> listProducer = new List<Producer>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listProducer.Add(new Producer((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listProducer;
        }
        public string GetProducer(int ID)
        {
            con.Open();
            string sqlString = "select Producer from ProducerID p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            string prod = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    prod = rdr["Producer"].ToString();
                }
            }
            con.Close();
            return prod;

        }
internal void AddNeproducer(int NewId, string NewProducer)
        {
            string sqlString = "INSERT INTO ProducerID (Id, Producer) VALUES (@val1, @val2);";

            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = con;
                comm.CommandText = sqlString;
                comm.Parameters.AddWithValue("@val1", NewId);
                comm.Parameters.AddWithValue("@val2", NewProducer);
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

        public int maxIdProducer()
        {
            con.Open();
            string sqlString = "select Max(Id) as Id from ProducerID;";
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