using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Models.ViewModel;

namespace StockManagementApp.DAL.Gateway
{
    public class SearchViewGateway :ConnectionGateway
    {
        public List<SearchViewModel> GetTotalItems(int companyID, int catagoryID)
        {
            string query = "SELECT Items.StockAQ as Quantity, Items.Name as ItemName, Companies.Company as CompanyName, Items.Reorder FROM Items INNER JOIN Companies ON Items.companyId = Companies.Id WHERE Items.CompanyId='" + companyID + "' AND CatagoryId='" + catagoryID + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<SearchViewModel> SearchResults = new List<SearchViewModel>();
            while (reader.Read())
            {
                SearchViewModel SearchResult = new SearchViewModel();
                SearchResult.ItemName = reader["ItemName"].ToString();
                SearchResult.CompanyName = reader["CompanyName"].ToString();
                SearchResult.Quantity = Convert.ToInt32(reader["Quantity"]);
                SearchResult.Reorder = Convert.ToInt32(reader["Reorder"]);



                SearchResults.Add(SearchResult);
            }

            connection.Close();

            return SearchResults;
        }

// Code for search without conditon
        public List<SearchViewModel> GetTotalItemsWithoutCondition()
        {
            string query = "SELECT Items.StockAQ as Quantity, Items.Name as ItemName, Companies.Company as CompanyName, Items.Reorder FROM Items INNER JOIN Companies ON Items.companyId = Companies.Id";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<SearchViewModel> SearchResults = new List<SearchViewModel>();
            while (reader.Read())
            {
                SearchViewModel SearchResult = new SearchViewModel();
                SearchResult.ItemName = reader["ItemName"].ToString();
                SearchResult.CompanyName = reader["CompanyName"].ToString();
                SearchResult.Quantity = Convert.ToInt32(reader["Quantity"]);
                SearchResult.Reorder = Convert.ToInt32(reader["Reorder"]);



                SearchResults.Add(SearchResult);
            }

            connection.Close();

            return SearchResults;
        }



        //Code for Search By CompanyID
        public List<SearchViewModel> SearchViewByCompanyID(int companyID)
        {
            string query = "SELECT Items.StockAQ as Quantity, Items.Name as ItemName, Companies.Company as CompanyName, Items.Reorder FROM Items INNER JOIN Companies ON Items.CompanyId = Companies.Id  WHERE Items.CompanyId=@companyID ";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyID", companyID);
            connection.Open();
            reader = command.ExecuteReader();

            List<SearchViewModel> companies = new List<SearchViewModel>();
            while (reader.Read())
            {
                SearchViewModel company = new SearchViewModel();
                company.ItemName = reader["ItemName"].ToString();
                company.CompanyName = reader["CompanyName"].ToString();
                company.Quantity = Convert.ToInt32(reader["Quantity"]);
                company.Reorder = Convert.ToInt32(reader["Reorder"]);



                companies.Add(company);
            }

            connection.Close();

            return companies;
        }

        //Code for Search by CategoryID
        public List<SearchViewModel> SearchViewByCategoryID(int categoryID)
        {
            string query = "SELECT Items.StockAQ as Quantity, Items.Name as ItemName, Companies.Company as CompanyName, Items.Reorder FROM Items INNER JOIN Companies ON Items.CompanyId = Companies.Id  WHERE Items.CatagoryId=@catagoryID";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@catagoryID", categoryID);
            connection.Open();
            reader = command.ExecuteReader();

            List<SearchViewModel> companies = new List<SearchViewModel>();
            while (reader.Read())
            {
                SearchViewModel SearchResult = new SearchViewModel();
                SearchResult.ItemName = reader["ItemName"].ToString();
                SearchResult.CompanyName = reader["CompanyName"].ToString();
                SearchResult.Quantity = Convert.ToInt32(reader["Quantity"]);
                SearchResult.Reorder = Convert.ToInt32(reader["Reorder"]);



                companies.Add(SearchResult);
            }

            connection.Close();

            return companies;
        }


// Search by Two Date
        public List<SearchViewModel> SearchViewBytwoDate(DateTime FromDate, DateTime ToDate)
        {

            string query = "SELECT Items.Name as ItemName, SUM(StockOut.Quantity) as Quantity FROM StockOut LEFT JOIN Items ON StockOut.ItemId= Items.Id WHERE StockOut.Date between @fromDate and @toDate AND Type ='SELL' GROUP BY Name";
          //  string query = "SELECT StockOut.Quantity as Quantity, Items.Name as ItemName, Companies.Company as CompanyName FROM StockOut INNER JOIN Items ON StockOut.ItemId= Items.Id INNER JOIN Companies ON Items.CompanyId = Companies.Id  WHERE StockOut.Date Between @fromDate and @toDate";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fromDate", FromDate);
            command.Parameters.AddWithValue("@toDate", ToDate);

            connection.Open();
            reader = command.ExecuteReader();

            List<SearchViewModel> searchResults = new List<SearchViewModel>();
            while (reader.Read())
            {
                SearchViewModel SearchResult = new SearchViewModel();
                SearchResult.ItemName = reader["ItemName"].ToString();
              //  SearchResult.CompanyName = reader["CompanyName"].ToString(); // Only for show Company Name
                SearchResult.Quantity = Convert.ToInt32(reader["Quantity"]);
                



                searchResults.Add(SearchResult);
            }

            connection.Close();

            return searchResults;
        }


 
    }
}