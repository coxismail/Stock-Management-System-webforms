using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.DAL.Gateway
{
    public class StockOutGateway:ConnectionGateway
    {
        public int StockOut(StockOutModel stockout)
        {

            string query = "INSERT INTO StockOut(ItemId, Type, Quantity, Date) VALUES('" + stockout.ItemId + "','" + stockout.Type + "','" + stockout.Quantity + "','" + stockout.Date + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
       
        
        
    }
}