using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using etgarPlus.Classes;

namespace etgarPlus
{
    public class OrdersDAL
    {

        public string s;
        public SqlConnection con;

        public OrdersDAL()
        {
            s = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 
            con = new SqlConnection(s);
            
        }
        public void AddNewOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            con.Open();

            con.Close();
        }
        public void UpdateOrder(int Id, int ClientID, int ProductID, int Quantity)
        {
            con.Open();

            con.Close();
        }

        public void DeleteOrder(int Id)
        {
            con.Open();
            string sqlString = @"DELETE FROM Orders o where o.Id = " + Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Order> GetOrderById(int Id)
        {
            con.Open();
            string sqlString = "select * from Orders o where o.Id = "+ Id + ";";
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }

        public List<Order> GetPriceOrder(int Id)
        {
            con.Open();
            string sqlString = "select * from Orders o ;";///////////////////////////////////
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }

        public List<Order> GetOrdersByClient(string Name)
        {
            con.Open();
            string sqlString = "select * from Orders";//////////////////////////////////
            SqlCommand com = new SqlCommand(sqlString, con);
            List<Order> listOrders = new List<Order>();
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    listOrders.Add(new Order((int)rdr[0], (int)rdr[1], (int)rdr[2], (int)rdr[3]));
                }
            }
            con.Close();
            return listOrders;
        }
    }
}