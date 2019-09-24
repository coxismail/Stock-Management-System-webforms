using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using StockManagementApp.DAL.Model;

namespace StockManagementApp.DAL.Gateway
{
    public class CompanyGateway :ConnectionGateway
    {
        

        public int save(CompanyModel companyRelator)
        {
            string query = "Insert Into Companies(Company) values(@company)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@company", companyRelator.Company);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();


            return rowAffect;
        }


        public bool IsExists(string company)
        {
            string query = "SELECT * FROM Companies WHERE Company=@company";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@company", company);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExists;
        }

        public List<CompanyModel> GetAllCompany()
        {
            List<CompanyModel> companyList = new List<CompanyModel>();
            String query = "SELECT * FROM Companies";
            command = new SqlCommand(query,connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CompanyModel companyRelator = new CompanyModel();
                companyRelator.Id = Convert.ToInt32(reader["Id"]);
                companyRelator.Company = reader["Company"].ToString();
                companyList.Add(companyRelator);
            }
            
            reader.Close();
            connection.Close();
            return companyList;
        }
    }
}