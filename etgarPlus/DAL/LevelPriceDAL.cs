using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;
using System.Diagnostics;
namespace etgarPlus.DAL
{
    public class LevelPriceDAL
    {
        
        public static string s;
        public SqlConnection con;
        public LevelPriceDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);            
        }
        public List<LevelPrice> getAllLevels()
        {
            con.Open();
            string sqlString = "select * from LevelPriceID";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<LevelPrice> listLevel = new List<LevelPrice>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listLevel.Add(new LevelPrice((int)rdr[0], (String)rdr[1]));
                }
            }
            con.Close();
            return listLevel;
        }
    }

  
}