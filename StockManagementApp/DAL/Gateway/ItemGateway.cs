using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementApp.DAL.Model;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.DAL.Gateway
{
    public class ItemGateway:ConnectionGateway
    {
       
        public int Save(ItemModel itemRelator)
        {
            string query = "Insert Into Items(CatagoryId, CompanyId, Name, Reorder) values(@catagoryid, @Companyid, @name, @reorder)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagoryId", itemRelator.CatagoryID);
            command.Parameters.AddWithValue("@companyId", itemRelator.CompanyID);
            command.Parameters.AddWithValue("@name", itemRelator.Name);
            command.Parameters.AddWithValue("@reorder", itemRelator.Reorder);

            connection.Open();

            int rowAffect = command.ExecuteNonQuery();
            connection.Close();


            return rowAffect;
        }

        public List<ItemModel> GetItemsByID(int Id)
        {
            List<ItemModel> ItemList = new List<ItemModel>();
            String query = "SELECT*FROM Items WHERE CompanyId=@companyid";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyid", Id);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ItemModel ItemRelator = new ItemModel();
                ItemRelator.Id = Convert.ToInt32(reader["Id"]);
                ItemRelator.Name = reader["Name"].ToString();
                ItemRelator.Reorder = Convert.ToInt32(reader["Reorder"]);
                ItemRelator.StockAQ = Convert.ToInt32(reader["StockAQ"]);
                ItemList.Add(ItemRelator);
            }
            reader.Close();
            connection.Close();
            return ItemList;
        }
        public ItemModel GetAllItemsByID(int Id)
        {
           
            String query = "SELECT*FROM Items WHERE Id= @itemID";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemID", Id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            ItemModel ItemRelator = null;
            if (reader.HasRows)
            {
                ItemRelator = new ItemModel();
                ItemRelator.Reorder = Convert.ToInt32(reader["Reorder"]);
                ItemRelator.StockAQ = Convert.ToInt32(reader["StockAQ"]);
              
            }
            reader.Close();
            connection.Close();
            return ItemRelator;
        }

        public int StockIn(ItemModel stockIn)
        {
            string query = "UPDATE Items SET StockAQ+= @stockinQ WHERE Id= @ItemsId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@stockinQ", stockIn.StockAQ);
            command.Parameters.AddWithValue("@ItemsId", stockIn.Id);
            connection.Open();

            int rowAffect = command.ExecuteNonQuery();
            connection.Close();


            return rowAffect;
        }



        public bool IsExists(ItemModel itemRelator)
        {
            string query = "SELECT * FROM Items WHERE CatagoryId =@catagoryId AND CompanyId =@companyId AND Name =@name AND Reorder =@reorder";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagoryId", itemRelator.CatagoryID );
            command.Parameters.AddWithValue("@companyId", itemRelator.CompanyID);
            command.Parameters.AddWithValue("@name", itemRelator.Name);
            command.Parameters.AddWithValue("@reorder", itemRelator.Reorder);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


        }
//for StockOut table
        public int GetStockAQById(int ItemId)
        {
            string query = "SELECT StockAQ FROM Items WHERE Id ='" + ItemId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int availableQuantity = Convert.ToInt32(reader["StockAQ"]);
                connection.Close();
                return availableQuantity;

            }

            connection.Close();
            return 0;
        }




        public int Update(ItemModel stockIn)
        {
            string query = "Update Items SET StockAQ='" + stockIn.StockAQ + "' WHERE  Id= '" + stockIn.Id + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }









    }
}