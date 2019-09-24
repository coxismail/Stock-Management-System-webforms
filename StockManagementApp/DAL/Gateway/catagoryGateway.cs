using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Web.Configuration;
using StockManagementApp.DAL.Model;
using StockManagementApp.DAL.Models;


namespace StockManagementApp.DAL.Gateway
{
    public class catagoryGateway:ConnectionGateway
    {
        
        public int save(CatagoryModel catagoryRelator)
        {
            string query = "Insert Into catagoris(catagory) values(@catagory)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagory", catagoryRelator.Catagory);

            connection.Open();

            int rowAffect = command.ExecuteNonQuery();
            connection.Close();


            return rowAffect;
        }

        public int Update(CatagoryModel catagoryRelator)
        {
            string query = "Update catagoris SET catagory = @catagory WHERE Id = @id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagory", catagoryRelator.Catagory);
            command.Parameters.AddWithValue("@Id", catagoryRelator.Id);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }




        public bool IsExists(string catagory)
        {
            string query = "SELECT * FROM Catagoris WHERE Catagory=@catagory";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagory", catagory);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


        }

        public List<CatagoryModel> GetAllCatagory()
        {
            List<CatagoryModel> catagoryList = new List<CatagoryModel>();
            String query = "SELECT*FROM Catagoris";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CatagoryModel CatagoryRelator = new CatagoryModel();
                CatagoryRelator.Id = Convert.ToInt32(reader["Id"]);
                CatagoryRelator.Catagory = reader["Catagory"].ToString();
                catagoryList.Add(CatagoryRelator);
            }
            reader.Close();
            connection.Close();
            return catagoryList;
        }

        public CatagoryModel GetCatagoryByID(int Id)
        {
            String query = "SELECT*FROM Catagoris WHERE Id = @Id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            CatagoryModel CatagoryRelator = null;
            if (reader.HasRows)
            {
                CatagoryRelator = new CatagoryModel();
                CatagoryRelator.Id = Convert.ToInt32(reader["Id"]);
                CatagoryRelator.Catagory = reader["Catagory"].ToString();
            }

            reader.Close();
            connection.Close();
            return CatagoryRelator;
        }



        public CatagoryModel DeleteCatagoryByID(int Id)
        {
            String query = "DELETE FROM Catagoris WHERE Id = @Id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            CatagoryModel CatagoryRelator = null;
            if (reader.HasRows)
            {
                CatagoryRelator = new CatagoryModel();
                CatagoryRelator.Id = Convert.ToInt32(reader["Id"]);
                CatagoryRelator.Catagory = reader["Catagory"].ToString();
            }

            reader.Close();
            connection.Close();
            return CatagoryRelator;
        }








    }
}