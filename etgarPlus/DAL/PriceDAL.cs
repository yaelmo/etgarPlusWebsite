using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace etgarPlus.DAL
{
    public class PriceDAL
    {
        public static string s;
        public SqlConnection con;
        public PriceDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }
        public String GetPrice(int ID)
        {
            con.Open();
            string sqlString = "select Details from LevelPriceID p where p.Id = " + ID.ToString() + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            String price = "";
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    price = rdr["Details"].ToString();
                }
            }
            con.Close();
            return price;

        }
    }
}